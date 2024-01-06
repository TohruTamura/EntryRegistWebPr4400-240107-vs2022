using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

namespace EntryRegistWebPr{

    class EventListJsonConvertClass {
        public const string EVENT_LIST_FILE_NAME = "EventList.txt";
        public const string HTML_FILE_NAME = "EventList.html";
		public const string TEST_HTML_FILE_NAME = "testEventList.html";

        public static string EventListJsonConverting(List<EventInfoClass> convertEventList) {
			List<EventToJsonClass> aJosonList =convertEventList.Select(aEventInfoC=>new EventToJsonClass(aEventInfoC)).ToList();
			return new JavaScriptSerializer().Serialize(aJosonList);
        }
    }
}
