/*
 * Tác giả: Lê Nguyễn Anh Bảo
 * Ngày viết: 20/09/2026
 */

/*
 * CHƯƠNG TRÌNH LỚP PERSONLIST
 *
 * Phát biểu đề bài:
 * PersonList quản lý nhiều Person: default/copy constructor, Input,
 * Output, Add và LivingPeople.
 *
 * Ý tưởng:
 * persons là List<Person>. LivingPeople duyệt danh sách và lấy
 * những người có IsLiving() = true.
 *
 * Mã giả:
 * 1   tạo result
 * 2   for mỗi p trong persons
 * 3       nếu p.IsLiving() thì result.Add(p)
 * 4   return result
 */
using System;
using System.Collections.Generic;
class Person
{
    private int id,yob,yod; private string name;
    public Person(){id=0;yob=0;yod=0;name="";}
    public Person(Person p){id=p.id;yob=p.yob;yod=p.yod;name=p.name;}
    public bool IsLiving(){return yod==0;}
    public void Input()
    {
        Console.Write("ID: ");id=int.Parse(Console.ReadLine()??"0");
        Console.Write("Name: ");name=Console.ReadLine()??"";
        Console.Write("YOB: ");yob=int.Parse(Console.ReadLine()??"0");
        Console.Write("YOD (0 neu con song): ");yod=int.Parse(Console.ReadLine()??"0");
    }
    public void Output(){Console.WriteLine("{0} - {1} - {2} - {3}",id,name,yob,yod);}
}
class PersonList
{
    private List<Person> persons;
    public PersonList(){persons=new List<Person>();}
    public PersonList(PersonList other)
    {
        persons=new List<Person>();
        foreach(Person p in other.persons)persons.Add(new Person(p));
    }
    public void Add(Person p){persons.Add(p);}
    public void Input()
    {
        Console.Write("Nhap so nguoi: ");int n=int.Parse(Console.ReadLine()??"0");
        for(int i=0;i<n;i++){Person p=new Person();p.Input();Add(p);}
    }
    public void Output(){foreach(Person p in persons)p.Output();}
    public PersonList LivingPeople()
    {
        PersonList kq=new PersonList();
        foreach(Person p in persons)if(p.IsLiving())kq.Add(new Person(p));
        return kq;
    }
}
class Bai2_2_PersonList
{
    static void Main(string[] args)
    {
        PersonList ds=new PersonList();ds.Input();
        Console.WriteLine("Danh sach:");ds.Output();
        Console.WriteLine("Nguoi con song:");ds.LivingPeople().Output();
    }
}
