
// on 11/08/01 RPを削除
namespace EntryRegistWebPr {
	class jcblMemberClass {
		public int jcblNumber;
		public string personName;
		public int sp;
		public int bp; //100倍
		public string sex; // M or F

		public jcblMemberClass(int aNumber, string aName, int aSp,int aBp,string aSex) {
			this.jcblNumber = aNumber;
			this.personName = aName;
			this.sp = aSp;
			this.bp=aBp;
			this.sex=aSex;
		}	
	}
}
