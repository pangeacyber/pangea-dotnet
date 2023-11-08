namespace PangeaCyber.Net.AuthN.Models
{
    ///
    public class FlowRestartData
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        protected FlowRestartData(Builder builder)
        {

        }

        /// <summary>
        ///
        /// </summary>
        public class Builder
        {
            ///
            public FlowRestartData Build()
            {
                return new FlowRestartData(this);
            }
        }

    }
}
