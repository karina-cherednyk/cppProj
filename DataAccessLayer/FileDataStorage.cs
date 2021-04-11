using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace g4m4nez.DataAccessLayer
{
    public class FileDataStorage<TObject> where TObject : class, IStorable
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData), "g4m4nezStorage", typeof(TObject).Name);

        public FileDataStorage()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
            }
        }

        public async Task AddOrUpdateAsync(TObject obj)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string stringObject = JsonSerializer.Serialize(obj, options);

            string filePath = Path.Combine(BaseFolder, obj.Guid.ToString(format: "N"));

            using StreamWriter sw = new(filePath, false);
            await sw.WriteAsync(stringObject);

        }

        public void Delete(TObject obj)
        {
            string filePath = Path.Combine(BaseFolder, obj.Guid.ToString(format: "N"));

            File.Delete(filePath);
        }

        public async Task<TObject> GetAsync(Guid guid)
        {
            string stringObject = null;

            string filePath = Path.Combine(BaseFolder, guid.ToString(format: "N"));
            if (!File.Exists(filePath))
            {
                return null;
            }

            using (StreamReader sr = new(filePath))
            {
                stringObject = await sr.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<TObject>(stringObject);
        }

        public async Task<List<TObject>> GetAllAsync()
        {
            List<TObject> res = new();

            foreach (string file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObject = null;


                using (StreamReader sr = new(file))
                {
                    stringObject = await sr.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<TObject>(stringObject));
            }

            return res;
        }
    }
}
