using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    class VideoDocument : MultimediaDocument
    {
        public int? FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
}
