// STYLE SHEET EXAMPLE

// 全般:
// - これはUnityプロジェクトで使用するためのスタイルガイドの例です。
// - これらのルールを省略したり追加したりして、チームの好みに合わせてください。
// - 疑問点がある場合は、チームの意見を優先してください。
// - このスタイルシート例を、コードスタイルガイドの出発点として利用してください。
// - Microsoftのフレームワークデザインガイドはこちら: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/
// - Googleのスタイルガイドはこちら: https://google.github.io/styleguide/csharp-style.html

// 命名規則と大文字小文字:
// - 通常はパスカルケースを使用します。(例: ExamplePlayerController, MaxHealth, etc.)
// - プライベートなローカル変数やパラメーターにはキャメルケースを使用します。(例: examplePlayerController, maxHealth, etc.)
// - スネークケース、ケバブケース、ハンガリアン記法は避けてください。

// 書式:
// - K&R(開き中括弧を同じ行に)かAllman(開き中括弧を新しい行に)のどちらかを選択してください。ここではAllmanを採用します。
// - 行は短くします。水平方向の空白を考慮してください。スタイルガイドで標準の行幅を定義してください。(80-120文字)
// - 条件式の前にはスペースを一つ入れます。例: while (x == y)
// - ブラケット([])内のスペースは避けてください。例: x = dataArray[index]
// - 関数名と括弧の間にはスペースを入れません。例: DropPowerUp(myPrefab, 0, 1);
// - 括弧と引数の間にはスペースを入れません。例: CollectItem(myObject, 0, 1);
// - 引数のカンマの後にはスペースを一つ入れます。例: CollectItem(myObject, 0, 1);
// - 見やすさのために空行を有効活用しましょう。

// コメント:
// - コメントでは"何を"や"どのように"よりも、"なぜ"が分かるように書きます。
// - コードの説明は // コメントでコードの近く(なるべく直前)に書きます。
// - SerializeFieldではコメントよりもTooltipを使用します。
// - regionを使うのはやめましょう。regionは大きなクラスを作ることを助長します。コードを折りたたむと読みにくくなります。
// - 法的な情報やライセンスに関する情報は、スペースを節約するために外部リファレンスへのリンクを使用します。
// - <summary>タグで public メソッドや関数の情報を記載すると、Intellisenseでコメントが表示されるようになります。


// using:
// - using はファイルの先頭に記述します。
// - 未使用の using は削除してください。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ネームスペース:
// - パスカルケースを使用します。特殊記号やアンダースコアは避けてください。
namespace StyleSheetExample
{

    // 列挙型:
    // - 列挙型名は単数形にします。
    // - プレフィックス(接頭辞)やサフィックス(接尾辞)は使用しません。
    public enum Direction
    {
        North,
        South,
        East,
        West,
    }

    // フラグ列挙型:
    // - フラグ列挙型の名前は複数形にします。
    // - プレフィックスやサフィックスは使用しません。
    // - バイナリ値の列揃えには列揃えを使用します。
    [Flags]
    public enum AttackModes
    {
        // Decimal                         // Binary
        None = 0,                          // 000000
        Melee = 1,                         // 000001
        Ranged = 2,                        // 000010
        Special = 4,                       // 000100

        MeleeAndSpecial = Melee | Special  // 000101
    }

    // インターフェース:
    // - 名前は形容詞にします。
    // - パスカルケースの名前の前に`I`をつけます。
    public interface IDamageable
    {
        // プロパティ:
        // - プロパティ名はパスカルケースにします。
        string DamageTypeName { get; }
        float DamageValue { get; }

        // メソッド:
        // - メソッド名はパスカルケースで、最初に動作を表す動詞か動詞句にします。
        // - パラメーター名はキャメルケースにします。
        bool ApplyDamage(string description, float damage, int numberOfHits);
    }

    public interface IDamageable<T>
    {
        void Damage(T damageTaken);
    }

    // クラスと構造体:
    // - 名前は名詞か名詞句にします。
    // - プレフィックスはつけません。
    // - ファイルごとに一つのMonoBehaviourを定義します。MonoBehaviourがある場合は、ファイル名を一致させます。
    public class StyleExample : MonoBehaviour
    {

        // フィールド: 
        // - 特殊文字(バックスラッシュやシンボル、Unicode文字)は避けてください。コマンドラインツールと干渉する可能性があります。
        // - 名前は名詞にしますが、ブール値は動詞で始めます。
        // - 意味のある名前を使用します。名前を検索可能で発音可能にします。省略形は使用しません(数式の場合は除く)。
        // - public なフィールドはパスカルケースを使用します。
        // - 変数は直接公開せずにプロパティを使用します。
        // - private なフィールドはキャメルケースを使用し、ローカル変数と区別するためにアンダースコアから始めます。
        // - private な static のフィールドはキャメルケースを使用し、`s_`を最初につけます。
        // - デフォルト修飾子(privateなど)は省略するか、記載するか、どちらかで統一します。この例では省略しています。

        int _elapsedTimeInDays;

        // インスペクターに private フィールドを表示したい場合は、[SerializeField]属性を使用します。
        // bool型は質問形式にします。
        [SerializeField] bool _isPlayerDead;

        // インスペクターでカスタムクラスPlayerStatsをグループ化して表示します。
        [SerializeField] PlayerStats _stats;

        // Range()属性は、値の範囲指定とインスペクターでのスライダー表示ができます。
        [Range(0f, 1f), SerializeField] float _rangedStat;

        // Tooltip属性は、フィールドの説明をインスペクターに表示するコメントとして使えます。
        [Tooltip("This is another statistic for the player."), SerializeField]
        float _anotherStat;


        // プロパティ:
        // - publicなプロパティは特殊文字を含まないパスカルケースを使用します。
        // - 読み取り専用のプロパティは => か、{get; private set;}を推奨します。
        // - 設定も必要な場合は {get; set; }を使用します。

        // privateなバッキングフィールド(記録用の private 変数)
        int _maxHealth;

        // 読み取り専用でバッキングフィールドを返します。
        public int MaxHealthReadOnly => _maxHealth;

        // 以下の書き方ならバッキングフィールドを省略できます。
        // public int MaxHealth { get; private set; }

        // 読み取り専用のプロパティを明示的に実装します。
        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        // 書き込み専用のプロパティを明示的に実装します。
        public int Health { private get; set; }

        // 明示的なセッターなしでバッキングフィールドに値を設定するメソッド。
        public void SetMaxHealth(int newMaxValue) => _maxHealth = newMaxValue;

        // バッキングフィールドを省略した自動実装プロパティ。
        public string DescriptionName { get; set; } = "Fireball";


        // イベント:
        // - イベント名は動詞句にします。
        // - 処理前イベントは進行形、処理後イベントは過去形にします。
        // - デリゲートはSystem.ActionやSystem.Funcを使用します(0から16個のパラメーターを取ることができます)。
        // - 必要な場合は独自のEventArgを定義します(System.EventArgsを継承するか、カスタムの構造体)。
        // - または、System.EventHandlerを使用します。どちらかを選択し、一貫して適用します。
        // - イベント名、イベントハンドラー( subscriber(購読者) / observer(観測者) )、イベント発生メソッド( publisher(パブリッシャー) / subject(サブジェクト) )の命名規則を選択します。
        // - 例: イベント/アクション = "OpeningDoor", イベント発生メソッド = "OnDoorOpened", イベントハンドラー = "MySubject_DoorOpened"

        // 処理前イベント
        public event Action OpeningDoor;

        // 処理後イベント
        public event Action DoorOpened;     

        public event Action<int> PointsScored;
        public event Action<CustomEventArgs> ThingHappened;

        // これらはイベントを発生させるメソッド(event raising methods)です。例: OnDoorOpened, OnPointsScored, etc.
        public void OnDoorOpened()
        {
            DoorOpened?.Invoke();
        }

        public void OnPointsScored(int points)
        {
            PointsScored?.Invoke(points);
        }

        // これは構造体で作成したカスタムEventArgです。
        public struct CustomEventArgs
        {
            public int ObjectID { get; }
            public Color Color { get; }

            public CustomEventArgs(int objectId, Color color)
            {
                this.ObjectID = objectId;
                this.Color = color;
            }
        }


        // メソッド:
        // - メソッド名は動作を示す動詞か動詞句で始めます。
        // - パラメータ名はキャメルケースです。

        // メソッドは動詞で始めます。
        public void SetInitialPosition(float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        // boolを返すメソッドは質問形式にします。
        public bool IsNewPosition(Vector3 newPosition)
        {
            return (transform.position == newPosition);
        }

        void FormatExamples(int someExpression)
        {
            // VAR:
            // - varは読みやすさや間違ったクラスへの代入を防ぐ効果があります。
            // - 戻り値の型が不明瞭な場合は var を使わないでください。
            var powerUps = new List<PlayerStats>();
            var dict = new Dictionary<string, List<GameObject>>();


            // SWITCH文:
            // - 様々な書式があります。チームに合ったスタイルガイドを作成して、それに従ってください。
            // - この例では、各caseとその下のbreakをインデントしています。
            switch (someExpression)
            {
                case 0:
                    // ..
                    break;
                case 1:
                    // ..
                    break;
                case 2:
                    // ..
                    break;
            }

            // 括弧:
            // - 一行の時でも括弧は残します。
            // - 或いは、デバッグしやすいように複数行にします。
            // - ネストされた複数行の文も括弧を残します。

            // 一行でも括弧を残します。
            for (int i = 0; i < 100; i++) { DoSomething(i); }

            // 一行でも行分割すれば、ブレークポインタを設定できてデバッグしやすくなります。
            for (int i = 0; i < 100; i++)
            {
                DoSomething(i);
            }

            // ネストされた複数行の文も括弧を残します。
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DoSomething(j);
                }
            }
        }

        void DoSomething(int x)
        {
            // .. 
        }
    }

    // その他のクラス:
    // - その他のヘルパー/非MonoBehaviourクラスを必要に応じてファイルに定義します。
    // - 以下はインスペクターにフィールドグループを表示するためのSerializableクラスの例です。
    [Serializable]
    public struct PlayerStats
    {
        public int MovementSpeed;
        public int HitPoints;
        public bool HasHealthPotion;
    }

}
