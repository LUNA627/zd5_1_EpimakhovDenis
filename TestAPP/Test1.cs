
using zd4_EpimakhovDenis;
namespace TestAPP
{
    [TestClass]
    public sealed class Test1
    {

        //Проверка стандартного расчета ежемесячного аннуитетного платежа
        [TestMethod]
        public void TestMethod1()
        {
            double credit = 100000;
            int term = 12;
            double percent = 20;
            double excpected = 9263.45;
            double actual = CreditCalculator.CalculateAnnuityMonthPayment(credit, term, percent);
            Assert.AreEqual(excpected, actual, 2);

        }

        //Минимальная сумма кредита и минимальный срок
        [TestMethod]
        public void TestMethod2()
        {
            double credit = 50000;
            int term = 6;
            double percent = 1;
            double excpected = 8357.66;
            double actual = CreditCalculator.CalculateAnnuityMonthPayment(credit, term, percent);
            Assert.AreEqual(excpected, actual, 2);
        }



        //Максимальная сумма кредита и максимальный срок
        [TestMethod]
        public void TestMethod3()
        {
            double credit = 100000000;
            int term = 360;
            double percent = 25;
            double excpected = 2084578.64;
            double actual = CreditCalculator.CalculateAnnuityMonthPayment(credit, term, percent);
            Assert.AreEqual(excpected, actual, 2);
        }




        //Процентная ставка равна нулю
        [TestMethod]
        public void TestMethod4()
        {
            double credit = 60000;
            int term = 24;
            double percent = 0;
            double excpected = 2500;
            double actual = CreditCalculator.CalculateAnnuityMonthPayment(credit, term, percent);
            Assert.AreEqual(excpected, actual, 2);
        }


        //Стандартный расчет общей суммы выплат
        [TestMethod]
        public void TestMethod5()
        {
            double monthlyPayment = 2500;
            int term = 24;
            double excpected = 60000;
            double actual = CreditCalculator.CalculateAnnuityTotalSum(monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }



        //Минимальные значения для расчета общей суммы
        [TestMethod]
        public void TestMethod6()
        {
            double monthlyPayment = 60000;
            int term = 1;
            double excpected = 60000;
            double actual = CreditCalculator.CalculateAnnuityTotalSum(monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }






        //Максимальные значения для расчета общей суммы
        [TestMethod]
        public void TestMethod7()
        {
            double monthlyPayment = 15000000;
            int term = 360;
            double excpected = 5400000000;
            double actual = CreditCalculator.CalculateAnnuityTotalSum(monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }


        //Стандартный расчет переплаты по кредиту
        [TestMethod]
        public void TestMethod8()
        {
            double creditSum = 15000000;
            double monthlyPayment = 2024936.55;
            int term = 12;
            double excpected = 9299238.6;
            double actual = CreditCalculator.CalculateAnnuityOverpayment(creditSum, monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }


        //Переплата при нулевой процентной ставке
        [TestMethod]
        public void TestMethod9()
        {
            double creditSum = 200000;
            double monthlyPayment = 16667;
            int term = 12;
            double excpected = 4;
            double actual = CreditCalculator.CalculateAnnuityOverpayment(creditSum, monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }



        //Максимальные значения для расчета переплаты
        [TestMethod]
        public void TestMethod10()
        {
            double creditSum = 100000000;
            double monthlyPayment = 1681708.33;
            int term = 360;
            double excpected = 505414998.80;
            double actual = CreditCalculator.CalculateAnnuityOverpayment(creditSum, monthlyPayment, term);
            Assert.AreEqual(excpected, actual, 2);
        }

    }
}
