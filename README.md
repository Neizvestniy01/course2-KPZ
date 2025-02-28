## Лабораторна робота 1

Принципи, дотримані в рамках лабораторної роботи:
- KISS (Keep It Simple, Stupid) - код написаний просто, бібліотека класів окремо від коду, де проводиться тестування
- YAGNI (You Aren`t Going to Need It) - в коді немає функціоналу, над яким було розпочато розробку і не закінчено, лише функціонал по завданням з лабораторної, нічого зайвого
- DRY (Don`t Repeat Yourself) - немає повторюваних 1 в 1 частин коду
- Fail Fast - виявлення можливих помилок в класі Reporting [приклад](https://github.com/Neizvestniy01/course2-KPZ/blob/Lab1/Lab1/ClassLibrary1/Class1.cs#L96-L118)
- Composition Over Inheritance - клас Reporting використовує Warehouse через композицію [приклад](https://github.com/Neizvestniy01/course2-KPZ/blob/Lab1/Lab1/ClassLibrary1/Class1.cs#L86-L90)
- SOLID (S - Single Responsibility Principle) - кожен клас виконує лише свою, поставлену йому задачу [приклад](https://github.com/Neizvestniy01/course2-KPZ/blob/Lab1/Lab1/ClassLibrary1/Class1.cs#L6-L26)
- SOLID (O - Open/Closed Principle) - класи можуть бути розширені, але функціонал залишиться незмінним (Warehouse не підпадає під цей принцип) [приклад](https://github.com/Neizvestniy01/course2-KPZ/blob/Lab1/Lab1/ClassLibrary1/Class1.cs#L28-L48)  
[діаграма](https://github.com/Neizvestniy01/course2-KPZ/blob/Lab1/Lab1/diagram.jpg)
