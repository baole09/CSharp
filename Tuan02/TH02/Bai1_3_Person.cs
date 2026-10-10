/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 19/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP PERSON
 *
 * Phát biểu đề bài:
 * Person gồm id, name, yob, yod; có default constructor, copy
 * constructor, Input, Output và IsLiving.
 *
 * Ý tưởng:
 * IsLiving() = true khi yod = 0; ngược lại false.
 *
 * Mã giả:
 * 1   nhập id,name,yob,yod
 * 2   nếu yod = 0 trả về true
 * 3   ngược lại trả về false
 */
using System;
class Person
{
    private int id, yob, yod;
    private string name;
    public Person() { id=0; name=""; yob=0; yod=0; }
    public Person(Person p) { id=p.id; name=p.name; yob=p.yob; yod=p.yod; }
    public void Input()
    {
        Console.Write("Nhap id: "); id=int.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap name: "); name=Console.ReadLine()??"";
        Console.Write("Nhap nam sinh: "); yob=int.Parse(Console.ReadLine()??"0");
        Console.Write("Nhap nam mat (0 neu con song): "); yod=int.Parse(Console.ReadLine()??"0");
    }
    public void Output()
    {
        Console.WriteLine("ID: {0}",id); Console.WriteLine("Name: {0}",name);
        Console.WriteLine("YOB: {0}",yob); Console.WriteLine("YOD: {0}",yod);
        Console.WriteLine("Dang song: {0}",IsLiving());
    }
    public bool IsLiving() { return yod==0; }
}
class Bai1_3_Person
{
    static void Main(string[] args)
    {
        Person p=new Person(); p.Input(); Console.WriteLine(); p.Output();
        Console.WriteLine("Ban sao:"); new Person(p).Output();
    }
}
