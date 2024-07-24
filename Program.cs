namespace Generic
{
    class Program
    {
        // 제네릭(일반화)
        // 박싱과 언박싱처럼 런타임에 데이터 간의 형변환을 실행하진 않는다, 여러타입들 다뤄야할때 효과적
        // 박싱 언박싱 보다 성능과 자원을 아낌
        // 타입을 잘못 지정할 경우, 컴파일 단계에서 에러를 발생시켜 타입의 안정성 보장
        static void Main(string[] args)
        {
            //<>안에 Myclass를 넣을시 Item을 상속받지 않은 클래스가 들어갔으므로 에러가 출력됨
            Inventory<Potion> potionInventory = new(10); // 제네릭을 선언 했으니 <> 안에 어떤 타입이 들어갈지 넣는다
            potionInventory.Add(new Potion("체력 포션"));
            potionInventory.Add(new Potion("마나 포션"));
            potionInventory.Add(new Potion("경험치 포션"));
            potionInventory.Add(new Potion("활력 포션")); // 포션 추가

            potionInventory.Remove(); //포션 삭제
            potionInventory.Remove();

            potionInventory.PrintItemNames(); // 인벤토리의 남은 포션 출력

        }
    }

    public class Myclass // Item을 상속받지 않는 임시 클래스 생성
    {

    }



    public abstract class Item //추상클래스 Item 생성 
    {
        public string Name { get; private set; }

        public Item(string name) // 생성자, string 타입 name을 받아 Name 필드에 넣는다.
        {
            {
                Name = name;
            }
        }
    }

    public class Potion : Item // 추상 클래스인 Item을 상속받는 클래스 생성
    {
        
        public Potion(string name) : base(name) // string name을 받아서 base인 Item의 name에 넣는다?
        {

        }
    }

    //T에는 Item을 상속받은 클래스만 넣을 수 있다.
    public class Inventory<T> where T : Item //클래스 자체를 제네릭으로 선언하는것도 가능 클래스내에서 미리 선언한 제네릭 타입을 자유롭게 사용 가능
    {// where T : Item 으로 제약조건을 걸면 Item을 상속받는 클래스만 입력 가능
        private T[] _list; // 어떤 타입의 아이템이 올지 모르니 제네릭으로 리스트를 만듬
        private int _index; // 배열의 인덱스 선언

        public Inventory(int size)
        {
            _list = new T[size]; // 사이즈를 입력받아 아이템을 보관할  배열 선언
        }
        public void Add(T item) // 아이템 넣기
        {
            if (_index < _list.Length)
            {
                _list[_index] = item; // 인덱스가 배열의 길이 안에 있는경우 아이템을 더함
                _index++; //인벤토리 다음칸으로 
            }
        }
        public void Remove() // 아이템 삭제
        {
            if(_index > 0)
            {
                _index--; // 현재 비어있는 인덱스에서 아이템이 있는 인덱스로 이동
                _list[_index] = null; // 인덱스를 NULL로 처리해 비우려는 순간 에러 = T가 어떤 타입일지 모르기 때문에 null이 가능한지 아닌지 모름, 제약조건을 달면 에러가 사라짐
            }
        }

        public void PrintItemNames() // 아이템 목록 출력
        {
            Console.WriteLine("아이템 목록 : ");
            foreach (T item in _list) //배열이 null이 아니면 들어있는 아이템의 이름 출력
            {
                if (item != null)
                {
                    Console.WriteLine(item.Name); // 제네릭으로 선언한 T가 어떤 타입일 지 모르기때문에 Name 필드를 가졌는지 모름, 제약조건을 달면 에러가 사라짐
                }
            }
        }

    }




}
