using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Drawing.Point;

namespace StarboundModTools.UI.Designer
{
    public class JsonTextWriterThing : JsonTextWriter
    {
        JsonSerializer serializer;

        public JsonTextWriterThing(TextWriter textWriter) : base(textWriter) {
            serializer = new JsonSerializer();
            
        }

        public void WriteProperty(KeyValuePair<String, Object> kvp) {
            this.WritePropertyName(kvp.Key);
            this.WriteValue(kvp.Value);
        }

        public override void WriteValue(Object value) {
            if (value is Point)
                base.WriteRawValue(JsonConvert.SerializeObject( new int[] { ((Point)value).X, ((Point)value).Y } ));
            else
                base.WriteValue(value);
        }
    }
}
