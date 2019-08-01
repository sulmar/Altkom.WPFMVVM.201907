using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWOP.Transport.FakeRepositories
{
    public class FileProfileRepository : IProfileRepository
    {
        private string filename;

        public FileProfileRepository(string filename)
        {
            this.filename = filename;
        }


        public void Add(Profile entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Profile> Get()
        {
            ICollection<Profile> profiles = new List<Profile>();

            string[] lines = File.ReadAllLines(filename);

            int id = 0;

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                string name = columns[0];
                string connectionString = columns[1];

                Profile profile = new Profile { Name = name, Id = id, ConnectionString = connectionString };

                profiles.Add(profile);

                id++;
            }

            return profiles;

        }

        public Profile Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}
