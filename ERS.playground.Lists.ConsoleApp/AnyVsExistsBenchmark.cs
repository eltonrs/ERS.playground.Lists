using BenchmarkDotNet.Attributes;

namespace ERS.playground.Lists.ConsoleApp
{
    [MemoryDiagnoser]
    public class AnyVsExistsBenchmark
    {
        private readonly int _count = 4000;
        private readonly int _min = 1;
        private readonly int _max = 2500;
        private readonly int _itemToFind = 1;

        private IEnumerable<int> randomizedEnumerableList;
        private List<int> randomizedList;
        private int[] randomizedArray;
        //private IEnumerable<int> orderedList;

        public AnyVsExistsBenchmark()
        {
            randomizedEnumerableList = GeneratedRandomList(_count, _min, _max);
            randomizedList = randomizedEnumerableList.ToList();
            randomizedArray = randomizedEnumerableList.ToArray();
            //orderedList = GeneratedOrderedList(_count, min, max);
        }

        [Benchmark]
        public void AnyOnEnumerableWithPredicate()
            => randomizedEnumerableList.Any(i => i == _itemToFind);

        [Benchmark]
        public void AnyOnListWithPredicate()
            => randomizedList.Any(i => i == _itemToFind);

        [Benchmark]
        public void AnyOnArrayWithPredicate()
            => randomizedArray.Any(i => i == _itemToFind);

        [Benchmark]
        public void AnyOnList()
            => randomizedList.Any();

        [Benchmark]
        public void AnyOnEnumerable()
            => randomizedEnumerableList.Any();

        [Benchmark]
        public void AnyOnArray()
            => randomizedArray.Any();

        [Benchmark]
        public void ExistsOnListWithPredicate()
            => randomizedList.Exists(i => i == _itemToFind);

        //[Benchmark]
        //static bool ExistsOnListWithPredicate(List<int> generatedList, int itemToFind)
        //    => generatedList.Exists(i => i == itemToFind);

        static IEnumerable<int> GeneratedOrderedList(int count, int min, int max)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                switch (Type.GetTypeCode(typeof(int)))
                {
                    case TypeCode.Int32:
                        var minValueInt = Convert.ToInt32(min);
                        var maxValueInt = Convert.ToInt32(max);
                        var generatedValueInt = Convert.ToInt32(rnd.Next(minValueInt, maxValueInt));

                        list.Add((int)(object)generatedValueInt);
                        break;

                    case TypeCode.Double:
                        var minValueDouble = Convert.ToDouble(min);
                        var maxValueDouble = Convert.ToDouble(max);
                        var generatedValueDouble = Convert.ToDouble(rnd.NextDouble() * (maxValueDouble - minValueDouble) + minValueDouble);

                        list.Add((int)(object)generatedValueDouble);
                        break;
                }
            }

            return list.Order();
        }

        static IEnumerable<int> GeneratedRandomList(int count, int min, int max)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                switch (Type.GetTypeCode(typeof(int)))
                {
                    case TypeCode.Int32:
                        var minValueInt = Convert.ToInt32(min);
                        var maxValueInt = Convert.ToInt32(max);
                        var generatedValueInt = Convert.ToInt32(rnd.Next(minValueInt, maxValueInt));

                        list.Add((int)(object)generatedValueInt);
                        break;

                    case TypeCode.Double:
                        var minValueDouble = Convert.ToDouble(min);
                        var maxValueDouble = Convert.ToDouble(max);
                        var generatedValueDouble = Convert.ToDouble(rnd.NextDouble() * (maxValueDouble - minValueDouble) + minValueDouble);

                        list.Add((int)(object)generatedValueDouble);
                        break;
                }
            }

            return list;
        }
    }
}
