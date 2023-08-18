# Unity C#コードスタイルガイド

Unity公式サイトの[Create a C# style guide: Write cleaner code that scales](https://resources.unity.com/games/create-code-style-guide-e-book)で紹介されていたコードスタイルサンプルをざっくり和訳して、ちょっと自分用にカスタマイズしたコードスタイル例です。

オリジナルは[こちら](https://github.com/thomasjacobsen-unity/Unity-Code-Style-Guide)


## コードスタイルガイドを用意する必要性とは？
チーム開発をする際に先立ってコードスタイルガイドを用意することで、開発メンバー者がどのようなルールに従ってコードを書くべきかを明確にすることができます。

コードの書き方に正解はありませんが、チーム全体でコードスタイルを統一することは読みやすく拡張性が高いコードの開発に役立ちます。

## オリジナルからの変更点
手軽さとUnityのクラスにあわせるために以下の修正をしました。

- デフォルト修飾子( private や this )は省略
- インターフェースのプロパティをパスカルケースに変更
- 変数は一律キャメルケース。privateの_は省略

以下を追加しました。

- public 変数のプロパティ化の推奨


## このガイドの使い方
既存のガイドラインを参考にして、自分たちのガイドラインを作成するのは良いやり方です。

Unity開発の際の一般的なコーディング規約については、[Unity公式サイト](https://resources.unity.com/games/create-code-style-guide-e-book)にて紹介されています。このガイドラインは[Microsoft Framework Design guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)を元に作成しています。

このガイドラインは参考にはなりますが絶対的なものではありません。疑問がある部分は、チームで話し合って合意できるルールに改めてください。個々のルールの詳細よりも、チーム全体でルールを統一することが重要です。


## 関連リンク
- [Create a C# style guide: Write cleaner code that scales](https://resources.unity.com/games/create-code-style-guide-e-book)
- [](https://github.com/thomasjacobsen-unity/Unity-Code-Style-Guide)
- [Unity Game Academy](https://github.com/UnityGameAcademy)
- [Naming and code style tips](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)
- [Formatting best practices](https://unity.com/how-to/formatting-best-practices-c-scripting-unity)

