// STYLE SHEET EXAMPLE

// GENERAL:
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

// FORMATTING:
// - K&R(開き中括弧を同じ行に)かAllman(開き中括弧を新しい行に)のどちらかを選択してください。ここではAllmanを採用します。
// - 行は短くします。水平方向の空白を考慮してください。スタイルガイドで標準の行幅を定義してください。(80-120文字)
// - 条件式の前にはスペースを一つ入れます。例: while (x == y)
// - ブラケット([])内のスペースは避けてください。例: x = dataArray[index]
// - 関数名と括弧の間にはスペースを入れません。例: DropPowerUp(myPrefab, 0, 1);
// - 括弧と引数の間にはスペースを入れません。例: CollectItem(myObject, 0, 1);
// - 引数のカンマの後にはスペースを一つ入れます。例: CollectItem(myObject, 0, 1);
// - 見やすさのために空行を有効活用しましょう。

// COMMENTS:
// - コメントでは"何を"や"どのように"よりも、"なぜ"が分かるように書きます。
// - コードの説明は // コメントでコードの近く(なるべく直前)に書きます。
// - SerializeFieldではコメントよりもTooltipを使用します。
// - regionを使うのはやめましょう。regionは大きなクラスを作ることを助長します。コードを折りたたむと読みにくくなります。
// - 法的な情報やライセンスに関する情報は、スペースを節約するために外部リファレンスへのリンクを使用します。
// - <summary>タグで public メソッドや関数の情報を記載すると、Intellisenseでコメントが表示されるようになります。


// USING LINES:
// - using はファイルの先頭に記述します。
// - 未使用の using は削除してください。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// NAMESPACES:
// - パスカルケースを使用します。特殊記号やアンダースコアは避けてください。
namespace StyleSheetExample
{

    // ENUMS:
    // - 型名は単数形にします。
    // - プレフィックス(接頭辞)やサフィックス(接尾辞)は使用しません。
    public enum Direction
    {
        North,
        South,
        East,
        West,
    }

    // FLAGS ENUMS:
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

    // INTERFACES:
    // - 名前は形容詞にします。
    // - パスカルケースの名前の前に`I`をつけます。
    public interface IDamageable
    {
        // PROPERTIES:
        // - プロパティ名はパスカルケースにします。
        string DamageTypeName { get; }
        float DamageValue { get; }

        // METHODS:
        // - メソッド名はパスカルケースで、最初に動作を表す動詞か動詞句にします。
        // - パラメーター名はキャメルケースにします。
        bool ApplyDamage(string description, float damage, int numberOfHits);
    }

    public interface IDamageable<T>
    {
        void Damage(T damageTaken);
    }

    // CLASSES or STRUCTS:
    // - 名前は名詞か名詞句にします。
    // - プレフィックスはつけません。
    // - ファイルごとに一つのMonoBehaviourを定義します。MonoBehaviourがある場合は、ファイル名を一致させます。
    public class StyleExample : MonoBehaviour
    {

        // FIELDS: 
        // - 特殊文字(バックスラッシュやシンボル、Unicode文字)は避けてください。コマンドラインツールと干渉する可能性があります。
        // - 名前は名詞にしますが、ブール値は動詞で始めます。
        // - 意味のある名前を使用します。名前を検索可能で発音可能にします。省略形は使用しません(数式の場合は除く)。
        // - public なフィールドはパスカルケースを使用します。
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


        // PROPERTIES:
        // - publicなプロパティは特殊文字を含まないパスカルケースを使用します。
        // - 読み取り専用のプロパティは => か、{get; private set;}を推奨します。
        // - 設定も必要な場合は {get; set; }を使用します。

        // privateなバッキングフィールド(記録用の private 変数)
        private int _maxHealth;

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


        // EVENTS:
        // - Name with a verb phrase.
        // - Present participle means "before" and past participle mean "after."
        // - Use System.Action delegate for most events (can take 0 to 16 parameters).
        // - Define a custom EventArg only if necessary (either System.EventArgs or a custom struct).
        // - OR alternatively, use the System.EventHandler; choose one and apply consistently.
        // - Choose a naming scheme for events, event handling methods (subscriber/observer), and event raising methods (publisher/subject)
        // - e.g. event/action = "OpeningDoor", event raising method = "OnDoorOpened", event handling method = "MySubject_DoorOpened"
   
        // event before
        public event Action OpeningDoor;

        // event after
        public event Action DoorOpened;     

        public event Action<int> PointsScored;
        public event Action<CustomEventArgs> ThingHappened;

        // These are event raising methods, e.g. OnDoorOpened, OnPointsScored, etc.
        public void OnDoorOpened()
        {
            DoorOpened?.Invoke();
        }

        public void OnPointsScored(int points)
        {
            PointsScored?.Invoke(points);
        }

        // This is a custom EventArg made from a struct.
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


        // METHODS:
        // - Start a methods name with a verbs or verb phrases to show an action.
        // - Parameter names are camel case.

        // Methods start with a verb.
        public void SetInitialPosition(float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        // Methods ask a question when they return bool.
        public bool IsNewPosition(Vector3 newPosition)
        {
            return (transform.position == newPosition);
        }

        private void FormatExamples(int someExpression)
        {
            // VAR:
            // - Use var if it helps readability, especially with long type names.
            // - Avoid var if it makes the type ambiguous.
            var powerUps = new List<PlayerStats>();
            var dict = new Dictionary<string, List<GameObject>>();


            // SWITCH STATEMENTS:
            // - The formatting can vary. Select one for your style guide and follow it.
            // - This example  indents each case and the break underneath.
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

            // BRACES: 
            // - Keep braces for clarity when using single-line statements.
            // - Or avoid single-line statement entirely for debuggability.
            // - Keep braces in nested multi-line statements.

            // This single-line statement keeps the braces...
            for (int i = 0; i < 100; i++) { DoSomething(i); }

            // ... but this is more debuggable. You can set a breakpoint on the clause.
            for (int i = 0; i < 100; i++)
            {
                DoSomething(i);
            }

            // Don't remove the braces here.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DoSomething(j);
                }
            }
        }

        private void DoSomething(int x)
        {
            // .. 
        }
    }

    // OTHER CLASSES:
    // - Define as many other helper/non-Monobehaviour classes in your file as needed.
    // - This is a serializable class that groups fields in the Inspector.
    [Serializable]
    public struct PlayerStats
    {
        public int MovementSpeed;
        public int HitPoints;
        public bool HasHealthPotion;
    }

}
