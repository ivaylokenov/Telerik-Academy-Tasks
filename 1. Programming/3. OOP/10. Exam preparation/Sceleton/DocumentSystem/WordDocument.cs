using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IDocument, IEncryptable, IEditable
    {
        private long? Characters { get; set; }
        private bool isEncrypted = false;

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public bool IsEncrypted
        {
            get
            {
                return this.isEncrypted;
            }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.Characters = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.Characters));
        }

        public override string ToString()
        {
            if (isEncrypted)
            {

                return string.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
