using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public abstract class BinaryDocument : Document, IDocument
    {
        private long? size;

        public long? Size
        {
            get { return this.size; }
            protected set { this.size = value; }
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.Size = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string,object>("size", this.Size));
        }
    }
}
