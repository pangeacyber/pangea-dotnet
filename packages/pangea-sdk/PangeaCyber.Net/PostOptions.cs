namespace PangeaCyber.Net
{
    /// <kind>class</kind>
    /// <summary>
    /// </summary>
    public class PostConfig
    {
        ///
        public bool PollResult { get; private set; }

        ///
        public FileData? FileData { get; private set; }

        ///
        public PostConfig(Builder builder)
        {
            PollResult = builder.PollResult;
            FileData = builder.FileData;
        }

        ///
        public class Builder
        {

            ///
            public bool PollResult { get; set; } = true; // By default try to poll result

            ///
            public FileData? FileData { get; set; } = null;

            ///
            public Builder()
            {
            }

            ///
            public Builder WithPollResult(bool pollResult)
            {
                PollResult = pollResult;
                return this;
            }

            ///
            public Builder WithFileData(FileData fileData)
            {
                FileData = fileData;
                return this;
            }

            ///
            public PostConfig Build()
            {
                return new PostConfig(this);
            }
        }
    }
};
