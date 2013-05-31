using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        private string name;
        private string content;
    
        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new ArgumentException("No such property!");
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            protected set
            {
                this.content = value;
            }
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);

            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[");

            properties.Sort((a, b) => a.Key.CompareTo(b.Key));

            foreach (var item in properties)
            {
                if (item.Value != null)
                {
                    result.Append(item.Key);
                    result.Append("=");
                    result.Append(item.Value);
                    result.Append(";");
                }
            }

            result.Remove(result.Length - 1, 1);
            result.Append("]");

            return result.ToString();
        }
    }
}
