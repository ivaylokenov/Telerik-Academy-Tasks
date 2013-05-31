using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument, IDocument
    {
        public int? SampleRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
}
