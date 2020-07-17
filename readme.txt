プレイヤー用サイト
	クイズ参加メンバー用の得点管理を目的とするツール。


使用方法
	1.[サーバーURL]/QuizKnock12HourPlayerにアクセスする。
	2.ユーザーごとのメールアドレスとパスワードでログインする。
	3.正解、誤答、リセットのアクションに合わせ、内容を修正してSaveを押す。


ユーザー追加方法
	1.[サーバーURL]/QuizKnock12HourPlayerにアクセスする。
	2.「Register as a new user」をクリックして開く。
	3.ログイン用の文字列(メールアドレス形式。存在しなくてもよい)とパスワードを入力し、「Register」ボタンを押す。
	4.qkidentity(ユーザー認証用のデータベース)にアクセスし、AspNetUsersテーブルの、登録したユーザーのEmailConfirmedフィールドをtrueにする。
		ローカルで実行している場合、「Register」ボタンを押して直後に開いたページで「Click here to confirm your account」をクリックする。
	5.登録したメールアドレスでログインする。
	6.プレイヤー名を設定して、Createボタンを押す。