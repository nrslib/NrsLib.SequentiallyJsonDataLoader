using System;

namespace NrsLib.SequentiallyJsonDataLoader.Setting {
    public class LoaderSetting {
        public string Suffix { get; private set; } = "";

        public void ChangeFileSuffix(string suffix) => Suffix = suffix ?? throw new ArgumentNullException(nameof(suffix));
    }
}
