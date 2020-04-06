using System;
using System.Collections.Generic;
using System.Text;

namespace CSVFileProcessor.Models
{
    public class WeeklySnapshotModel
    {
        public WeeklySnapshotModel()
        {
            this.ExternalLinksInfo = new List<string>();
        }

        public WeeklySnapshotModel(int id, string name, string internalUrl, ICollection<string> externalLinkInfo)
            : base()
        {
            this.Id = id;
            this.Name = name;
            this.InternalUrl = internalUrl;
            this.ExternalLinksInfo = externalLinkInfo;
            this.Guid = default(Guid);
            this.Genre = null;
        }

        public WeeklySnapshotModel(int id, string name, string internalUrl, ICollection<string> externalLinkInfo, string genre)
            : base()
        {
            this.Id = id;
            this.Name = name;
            this.InternalUrl = internalUrl;
            this.ExternalLinksInfo = externalLinkInfo;
            this.Guid = default(Guid);
            this.Genre = genre;
        }

        public WeeklySnapshotModel(int id, string name, string internalUrl, ICollection<string> externalLinkInfo, Guid guid)
            : base()
        {
            this.Id = id;
            this.Name = name;
            this.InternalUrl = internalUrl;
            this.ExternalLinksInfo = externalLinkInfo;
            this.Guid = guid;
            this.Genre = null;
        }

        public WeeklySnapshotModel(int id, string name, string internalUrl, ICollection<string> externalLinkInfo, Guid guid, string genre)
            : base()
        {
            this.Id = id;
            this.Name = name;
            this.InternalUrl = internalUrl;
            this.ExternalLinksInfo = externalLinkInfo;
            this.Guid = guid;
            this.Genre = genre;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Guid Guid { get; set; }

        public string Genre { get; set; }

        public string InternalUrl { get; set; }

        public ICollection<string> ExternalLinksInfo { get; set; }
    }
}
