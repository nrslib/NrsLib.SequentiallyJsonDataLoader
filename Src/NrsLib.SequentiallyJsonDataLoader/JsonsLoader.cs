using System;
using System.Collections.Concurrent;
using System.IO;
using NrsLib.SequentiallyJsonDataLoader.Setting;

namespace NrsLib.SequentiallyJsonDataLoader {
    public class JsonsLoader {
        private readonly ConcurrentDictionary<Type, object> files = new ConcurrentDictionary<Type, object>();
        private readonly string fileDirectory;

        public JsonsLoader(string fileDirectory) {
            this.fileDirectory = fileDirectory;
        }

        public LoaderSetting Setting { get; } = new LoaderSetting();

        public T Generate<T>() {
            var type = typeof(T);
            var jsonFile = (JsonsFile<T>)files.GetOrAdd(type, t => {
                var path = Path.Combine(fileDirectory, $"{type.Name}{Setting.Suffix}.jsons");
                return new JsonsFile<T>(path);
            });
            return jsonFile.Next();
        }
    }
}
