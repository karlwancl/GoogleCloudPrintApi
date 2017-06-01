using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Attributes;

namespace GoogleCloudPrintApi.Models.Job
{
    /// <summary>
    /// Job state. ControlRequest uses it, use get; set;
    /// </summary>
    public class JobState
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeType
        {
            DRAFT = 0,
            HELD = 1,
            QUEUED = 2,
            IN_PROGRESS = 3,
            STOPPED = 4,
            DONE = 5,
            ABORTED = 6
        }

        public class UserActionCauseObject
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum ActionCodeType
            {
                CANCELLED = 0,
                PAUSED = 1,
                OTHER = 100
            }

            [FormKey("action_code")]
            public ActionCodeType ActionCode { get; set; }
        }

        public class DeviceStateCauseObject
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum ErrorCodeType
            {
                INPUT_TRAY = 0,
                MARKER = 1,
                MEDIA_PATH = 2,
                MEDIA_SIZE = 3,
                MEDIA_TYPE = 4,
                OTHER = 100
            }

            [FormKey("error_code")]
            public ErrorCodeType ErrorCode { get; set; }
        }

        public class DeviceActionCauseObject
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum ErrorCodeType
            {
                DOWNLOAD_FAILURE = 0,
                INVALID_TICKET = 1,
                PRINT_FAILURE = 2,
                OTHER = 100
            }

            [FormKey("error_code")]
            public ErrorCodeType ErrorCode { get; set; }
        }

        public class ServiceActionCauseObject
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum ErrorCodeType
            {
                COMMUNICATION_WITH_DEVICE_ERROR = 0,
                CONVERSION_ERROR = 1,
                CONVERSION_FILE_TOO_BIG = 2,
                CONVERSION_UNSUPPORTED_CONTENT_TYPE = 3,
                DELIVERY_FAILURE = 11,
                EXPIRATION = 14,
                FETCH_DOCUMENT_FORBIDDEN = 4,
                FETCH_DOCUMENT_NOT_FOUND = 5,
                GOOGLE_DRIVE_QUOTA = 15,
                INCONSISTENT_JOB = 6,
                INCONSISTENT_PRINTER = 13,
                PRINTER_DELETED = 12,
                REMOTE_JOB_NO_LONGER_EXISTS = 7,
                REMOTE_JOB_ERROR = 8,
                REMOTE_JOB_TIMEOUT = 9,
                REMOTE_JOB_ABORTED = 10,
                OTHER = 100
            }

            [FormKey("error_code")]
            public ErrorCodeType ErrorCode { get; set; }
        }

        [FormKey]
        public TypeType Type { get; set; }

        [FormKey("user_action_cause")]
		public UserActionCauseObject UserActionCause { get; set; }

        [FormKey("device_state_cause")]
		public DeviceStateCauseObject DeviceStateCause { get; set; }

        [FormKey("device_action_cause")]
		public DeviceActionCauseObject DeviceActionCause { get; set; }

        [FormKey("service_action_cause")]
		public ServiceActionCauseObject ServiceActionCause { get; set; }
    }
}
