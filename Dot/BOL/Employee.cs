namespace BOL;
using System;
using System.ComponentModel.DataAnnotations;
public class Employee
{
public int eid{get;set;}
[Required]
public string ename{get;set;}
[Required]
public string designation{get;set;}
}
