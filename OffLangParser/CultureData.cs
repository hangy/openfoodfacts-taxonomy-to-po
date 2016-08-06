namespace OffLangParser
{
    using System;
    using System.Globalization;

    public class CultureData
    {
        private readonly string name;

        private readonly CultureInfo info;

        public CultureData(CultureInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.name = info.Name;
            this.info = info;
        }

        public CultureData(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.name = name;
            this.info = CultureInfo.InvariantCulture;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public CompareInfo CompareInfo
        {
            get
            {
                return this.info.CompareInfo;
            }
        }

        public override int GetHashCode()
        {
            return this.GetTuple().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var data = obj as CultureData;
            if (data == null)
            {
                return false;
            }

            return data.GetTuple().Equals(this.GetTuple());
        }

        private Tuple<string, CultureInfo> GetTuple()
        {
            return Tuple.Create(this.name, this.info);
        }
    }
}
