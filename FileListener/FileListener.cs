using FileListener.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileListener.Utilities
{
    public class FileListener : IDisposable, ISwitchable
    {
        String path;
        int idle;
        bool running;

        public FileListener() {
            path = null;
            idle = 100;
            running = false;
        }

        public FileListener(String filePath) {
            path = filePath;
            idle = 100;
            running = false;
        }

        public String FilePath
        {
            set { path = value; }
            get { return path; }
        }

        public int ScanIdleTime
        {
            set { idle = value; }
            get { return idle; }
        }

        public void Dispose() {
            Stop();
        }

        public bool IsRunning() {
            return running;
        }

        public void Start() {
            if (File.Exists(FilePath)) {
                Thread scan = new Thread(scanFile);
                scan.Start();
                running = true;
            } else {
                Console.WriteLine("Could not find a file in " + FilePath);
            }
        }

        public void Stop() {
            running = false;

        }

        void scanFile() {
            try {
                using(StreamReader reader = new StreamReader(
                    new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {

                    //start at the end of the file
                    long lastMaxOffset = reader.BaseStream.Length;

                    while (IsRunning()) {
                        Thread.Sleep(ScanIdleTime);

                        //if the file size has not changed, idle
                        if (reader.BaseStream.Length == lastMaxOffset)
                            continue;
                        else if(reader.BaseStream.Length < lastMaxOffset) {
                            lastMaxOffset = reader.BaseStream.Length;
                            reader.BaseStream.Position = reader.BaseStream.Length;
                            continue;
                        }

                        //seek to the last max offset
                        reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                        //read out of the file until the EOF
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            sendEvent(line);

                        //update the last max offset
                        lastMaxOffset = reader.BaseStream.Position;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        #region Event
        public event NewLine OnOutput;
        public delegate void NewLine(Object sender, String line);

        protected void sendEvent(params String[] lines) {
            if (OnOutput != null && lines != null) {
                foreach (String s in lines) {
                    OnOutput(this, s);
                }
            }
        }
        #endregion
    }
}
