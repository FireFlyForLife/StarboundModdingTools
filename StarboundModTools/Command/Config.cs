using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Command
{
    public class Config : ICommand
    {
        Dictionary<String, List<String>> configs;

        //TODO: Add auto loading config
        public Config() {
            configs = new Dictionary<string, List<string>>();
        }

        public string Description
        {
            get
            {
                return "Create groups of variables and save and load them from disk.";
            }
        }

        public string Name
        {
            get
            {
                return "config";
            }
        }

        public string Usage
        {
            get
            {
                return "Usage: config create <config_name> - Makes a new config named after <config_name>." + 
                    "\nOr: config destroy <config_name> - Destroys the config named <config_name>." +
                    "\nOr: config list <config_name> - Lists all key/value vars part of <config_name>." +
                    "\nOr: config add <config_name> <key> - Adds the <key> to the <config_name>." +
                    "\nOr: config del <config_name> <key> - Delete the <key> from the <config_name>." +
                    "\nOr: config save <config_name> [file_name] - saves the config to a file, [file_name] is optional." +
                    "\nOr: config load <file_name> [config_name] - loads the config from <file_name>, optionally renames the config to [config_name].";
            }
        }

        public void Run(string[] args) {
            if (args.Length == 1) {
                return;
            }
            if (args.Length > 3) {
                if (args[1].Equals("add"))
                    Add(args[2], args[3]);
                else if (args[1].Equals("del"))
                    Del(args[2], args[3]);
            }
            if (args.Length > 2) {
                if (args[1].Equals("create"))
                    Create(args[2]);
                else if (args[1].Equals("destroy"))
                    Destroy(args[2]);
                else if (args[1].Equals("list"))
                    ShowList(args[2]);
                else if (args[1].Equals("save"))
                    Save(args[2], args.Length > 3 ? args[3] : args[2] + ".conf");
                else if (args[1].Equals("load")) {
                    if(args[2].EndsWith(".conf"))
                        Load(args[2], args.Length > 3 ? args[3] : args[2].Substring(0, args[2].Length - ".conf".Length));
                    else
                        Load(args[2], args.Length > 3 ? args[3] : args[2]);
                }
            } 
        }

        void Create(String name) {
            if (configs.ContainsKey(name))
                Console.WriteLine("A config named: " + name + " already exists.");
            else {
                configs.Add(name, new List<string>());
                Console.WriteLine("Succesfully created config: " + name);
            }
        }

        void Destroy(String name) {
            if (!configs.ContainsKey(name))
                Console.WriteLine("A config named: " + name + " does not exist.");
            else {
                configs.Remove(name);
                Console.WriteLine("Succesfully destroyed config: " + name);
            }
        }

        void ShowList(String name) {
            List<String> l;
            if (configs.TryGetValue(name, out l)) {
                Console.Write("Config " + name + " contains the keys: ");
                for (int i = 0; i < l.Count; i++) {
                    Console.Write(l.ElementAt(i));
                    if (i < l.Count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
           } else {
                Console.WriteLine("A config named: " + name + " does not exist.");
           }
        }

        void Add(String name, String key) {
            List<String> l;
            if(configs.TryGetValue(name, out l)) {
                if (!l.Contains(key)) {
                    l.Add(key);
                    Console.WriteLine("Succesfully added key: " + key + " to config: " + name);
                }
            } else {
                Console.WriteLine("A config named: " + name + " does not exist");
            }
        }

        void Del(String name, String key) {
            List<String> l;
            if (configs.TryGetValue(name, out l)) {
                if (l.Remove(key))
                    Console.WriteLine("Succesfully removed key: " + key + " from the config: " + name);
                else
                   Console.WriteLine("Did not find key: " + key + " in config: " + name);
            } else {
                Console.WriteLine("A config named: " + name + " does not exist");
            }
        }

        //LOOKAT: Check if key doesnt have ':' in it.
        //MAYBE: Find more dangerous chars
        //TODO: Save booleans differently
        void Save(String name, String file) {
            List<String> l;
            if (configs.TryGetValue(name, out l)) {
                using (StreamWriter sw = File.CreateText(file)) {
                    try {
                        foreach(String s in l) {
                            sw.WriteLine(s + ":" + SVars.getValue<object>(s)?.ToString());
                        }
                        Console.WriteLine("Succesfully saved config: " + name + " to file: " + file);
                    } catch (IOException ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            } else
                Console.WriteLine("Could not find config: " + name);
        }

        //TODO: Load Booleans differently
        void Load(String file, String name) {
            if (configs.ContainsKey(name))
                Console.WriteLine("Config: " + name + " already exists");
            else {
                try {
                    using (StreamReader sw = File.OpenText(file)) {
                        List<String> keys = new List<string>();
                        for(String line = sw.ReadLine(); line != null; line = sw.ReadLine()) {
                            int split = line.IndexOf(':');
                            if(split != -1) { 
                                String key = line.Substring(0, split);
                                String value = line.Substring(split + 1);
                                keys.Add(key);
                                SVars.Add(key, value);
                            } else
                                Console.WriteLine("line in file {0} is not standard", file);

                            line = sw.ReadLine();
                        }
                        configs.Add(name, keys);
                        Console.WriteLine("Succesfully loaded config: " + name + " to file: " + file);
                    }
                } catch (IOException ex) {
                    Console.WriteLine("Something went wront loading: {0}", ex.Message);
                }
            }
        }
    }
}
