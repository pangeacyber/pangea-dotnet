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
        public FileStream? FileStream { get; private set; }

        ///
        public PostConfig(Builder builder)
        {
            PollResult = builder.PollResult;
            FileStream = builder.FileStream;
        }

        ///
        public class Builder
        {

            ///
            public bool PollResult { get; set; } = true; // By default try to poll result

            ///
            public FileStream? FileStream { get; set; } = null;

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
            public Builder WithFileStream(FileStream fileStream)
            {
                FileStream = fileStream;
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
