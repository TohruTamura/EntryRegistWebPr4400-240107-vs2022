using System;
using System.Threading;
using System.Windows.Forms;

// on 09/08/13 締切日はなくす
// on 09/08/19 ASP.NET 2.0 Extensionsを使用する
// on 10/01/31 ServerClassを削除
// on 10/02/20 upLoadBtnを作成
// on 10/03/16 ofunabc用に、FTPホスト名に/docsを追加
// on 10/03/16 表示設定で、ホームページが開いていない状態で、保存した時エラーが出るバグを修正
// on 10/03/17 Entry数にCancelが含まれているバグを修正
// on 10/03/18 isComfirmWebはXPでは動いた
// spDispFlagをEventInfoClassに追加
// EventToJsonClassにspDispFlagを追加
// on 10/03/19
// delegateを使用
// on 19/03/20
// 受付番号順にソートしてアップロード
// on 10/03/21 
// 非公開情報ファイルは最初に読む
// on 11/09/28 表示のURLを追加した
// on 1/10/18 help2を組み込み
// on 11/10/11 MaxMembersが計算されないバグを修正
// on 11/10/18  GetFtpDirectoryOnlyListでkeepAlive=falseを設定
// on 11/10/28 MaxMembersでバグが出たので古いバージョンに戻す
// on 11/11/29 Web Server上のデータに不正なデータがあるとき、エラーメッセージを表示
// ver.1.998 on 12/04/03
// 登録テストOK
// mpInfoのアップロードOK
// mpInfoのfolder削除OK
// tempRegist.jsn表示OK
// Spのある情報の保存OK
// on 12/05/01 データが何もない場合、MaxMembersが0になるバグを修正
// タブを読む。1がいくつあるか見る=>MaxMembers
// on 12/07/09 データが何もない場合、getMaxEntryNumber(WebEntryForm)でエラーになるバグを修正
// on 12/07/10 tempRegistの必須事項が全て入力されているかチェックする。tempRegist.jsnをtempRegistTest.jsnとしてテストする
// eventIdからEventInfoClassを取り出すルーチンを作成
// 名前が同じ人で会員番号が違っていてもすでにエントリーしていることになってしまう。javaScriptの方はOKだった。
// dataが正しいかチェックした
// on 12/07/15 getEachEventInfoのバグを修正 
// on 12/08/02 エントリーがない競技会の時、受付番号が2から始まる。getMaxEntryNumbesのバグ 1->0へ修正
// on 12/10/12 非会員情報が表示されない
// EntryToJsonClassでjcblNumberが0の時無視するようにしていたのを、personNameがNullOrEmptyで判断するように変更
// on 12/11/22 DB version
// on 12/12/03 非公開情報はそこにデータがあるかどうかで判断する。確認は求めない。
// on 12/12/08 一斉メール送信機能を追加
// on 12/12/10 Access DBにmailAddressを保存
// on 12/12/21 upload情報を保存
// on 12/12/28 ver.2975
// アップロード時、終了時にプログラム起動後の申込があった場合、DBに登録後アップする。
// プログラム起動後の申込があった場合、mainFormにその数を表示(default=10秒おきに設定),間隔の設定も可能に
// on 13/01/06 BPに0が入るバグを修正
// on 13/02/03 taskScheduleメールを削除
// on 13/02/05 WebFormat Tableを変更したことに対応
//・webentryaddress Tableを削除
//・centernameをshortcenternameに変更
//・longcenternameを追加
//・urlandfoldernameを追加
// on 13/02/09 php処理を最適化
// on 13/02/10 phpプログラムをdbParam.を読み込むように変更
// getMpInfoYearAndMonth.php
// mySql.php
// newEntrySave.php
// mpInfoSave.php
// 2013/02/12 ver 3.002 
// uploadFlag & closingFlagの設定が開いた時にされていなかった
// on 13/02/27 6人の申込可能に4人で申し込んだ時のエラーを修正 ver3003
// on 13/03/24 ver3010 SpDispFlagを導入
// WebのEvent Tableに spDispFlagを作成
// AccessのEvent Tableに spDispFlagを作成 済み
// AccessのEvent Tableの読み込み、書込ルーチン 済み
// CheckBox表示ルーチン 済み
// CheckBoxの保存、Readルーチン 済み
// 全てをチェック、全てをクリアroutine 済み
// Event Data Json convert routine 済み
// php 変更
// entryInfoUpload.php, getDispEntryList.php
// DBに保存する部分をコメント化、phpのテストは行わない
//  on 17/04/22 新Domain用
// password 保存、readの確認
// phpFolderNameの取得をhomePageUrlから
// on 17/04/23 fileUploadを変更
// jcblInfo,mpInfo upload 終了
// on 17/08/17 jcblInfo及びmpInfoのアップロードが失敗するエラーを回避
// mailは直接書込
// on 22/08/31 Cancelしたメンバーが再エントリーした時、保存されない現象を修正
// 22/09/01 splush Form
namespace EntryRegistWebPr {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			splushFrm fs = new splushFrm();
			fs.Show();
			fs.Refresh();
			Thread.Sleep(1000);//時間のかかる処理
			fs.Close();
			Application.Run(new HomePageFrm());
        }
    }
}