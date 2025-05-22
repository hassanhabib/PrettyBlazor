﻿<p align="center">
  <img width="25%" height="25%" src="https://raw.githubusercontent.com/hassanhabib/PrettyBlazor/master/PrettyBlazor/PrettyBlazor.png">
</p>

[![.NET](https://github.com/hassanhabib/PrettyBlazor/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/PrettyBlazor/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/PrettyBlazor)](https://www.nuget.org/packages/PrettyBlazor/)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)
![The Standard Licensed](https://img.shields.io/badge/The%20Standard-License-green)

# PrettyBlazor
PrettyBlazor is a Blazor .NET library that enables Blazor developers to use control structures in their Blazor applications through markup without having to use obtrusive C# code to iterate or select particular fragments.

## Introduction
There are two concepts here that makes PrettyBlazor important for writing clean, readable and unobtrusive Blazor applications.

### Control Structures
In computer sciences there are three types that makes the types of control for any given program. These types are sequence, selection and iteration.

#### Sequential Structures
Sequence already exists in any markup language, as it simply means you can sequentially build markup blocks one after another and they shall render accordingly as follows:

```html
<TextBoxComponent />
<ButtonComponent Label="Submit" />
```

#### Selection Structures
Selection structures are responsible for executing particular blocks of code only when a given evaluation or a condition is positive. the most common example for selection structures are the `if-else` statements, but it extends to other forms such as `switch case`.
Most of Blazor developers today will handle the selection flow by simply directly adding obstrusive C# code into their `.razor` files as follows:
```html
@if(condition)
{
    <SomeComponent />
}
else 
{
    <SomeOtherComponent />
}
```
The problem with the above code snippet is that it violates multiple principles. For instance, it's very cognitive-resources consuming to write a particular file of code with two different languages. You require the engineers reading the code to mentally switch back and forth between C# and Markup to understand what your code is actually trying to accomplish.
This might not be a big deal when writing a simple demo "Hello, World!" program. but for large scale enterprise applications this could become quite consuming and may cripple the ability for some engineers to easily detect any issues in your code.
The issue with obtrusiveness in C# code with Markup in Blazor is that the text editor and the parser are in continuous intrepretation of what your code is actually to accomplish, which can have some performance issues as well.

With Pretty Blazor, the equation becomes much simpler, because the entire file will be written simply by one and only one language which is markup as follows:

```html
<Condition Evaluation="condition">
    <Match>
        <SomeComponent />
    </Match>
    <NotMatch>
        <SomeOtherComponent />
    </NotMatch>
</Condition>
```
In the code snippet above, you can see the selection structure completely implemented with just markup. the only C# code in this place is just the references to a boolean calculated value which belongs in the C# file for this application.
This approach of implementing selection control structure, is more befitting for the overall flow of a markup language in general, it expresses the structure much more fluently without any interruptions using a different language or a technology.
Every scripting, markup or programming language out there has the ability to express the type of control in their own way, for instance, CSS expresses selection control as follows:
```css
#button {
    color: red;
}
```
This is basically CSS way of saying, if the element id is named `#button` then go a head and assign color red to it.
The same thing goes for all other scripting and programming languages, very few on the markup side, therefore PrettyBlazor brings this level of control to the markup world with Blazor components.

#### Iteration Structures
Iteration is one of the most powerful features in every scripting or programming language. Just like selection and sequence it is very heavily used almost in every single application on the planet. Iteration allows engineers to pass in a list of items and have some form or redundant routines to execute on each one of these items.
Today in Blazor, you'll see a lot of applications being written as follows:

```html
@foreach(Student student in students)
{
    <StudentComponent Value=student />
}
```
And again, the problem with this structure here is the obtrusive nature of the implementation, which requires multiple technologies and programming/markup language to collide to achieve a certain implementation.
Some folks decided to take the route of building the entire component in C# then just return a rendered component or a fragment on the markup, and that's one way and rather hard way to solve the problem. But an easier approach would be to implement the same concept with a fluent markup expression as follows:

```html
<Iterations Items="Students">
  <StudentComponent Value="@context" />
</Iterations>
```
In the code snippet above, you can see how simpler, easier and prettier it can be to express an iteration in Blazor without having to write any specific C# code in your markup.
And just like we said in the selection section, the iteration control structure can be seen in every scripting, styling and programming language out there, for instance, in CSS iterations can be implemented as follows:

```css
button {
    color: red;    
}
```
In the example above, every single element of type button will have the color red. This is just another form of expressing iterations.

#### Loading Structures
One of the most common practices in UI programming is to show or hide certain elements based on the readiness of a specific piece of data. The "loading component" is responsible for evaluating this data to determine whether it is available and ready to be displayed. Additionally, loading components also allow developers to pass in a list of items and display an empty fragment when the list is empty. 
This is commonly seen in Blazor applications, where you'll often find code written in the following way:

```html
@if(isLoading) 
{
  @:Loading...
} 
else if (!isLoading && students.Length == 0) 
{
  @:No results!
}
else
{
  <StudentsComponent Value=students />
}
```
One issue with the current implementation is that it requires the use of multiple technologies and programming/markup languages, making it complex and hard to read. A simpler alternative would be to implement the same concept using a fluent markup expression, such as the following:

```html
<Loading Evaluation="Students">
  <Pending>Loading..</Pending>
  <Ready>
    <StudentsComponent Value=students />
  </Ready>
  <Empty>No results!</Empty>
</Loading>
```
The code snippet shown above demonstrates how it is possible to express a loading indicator and an empty result view in Blazor in a simpler, more readable and elegant way, without the need for any additional C# code in the markup.

### Unobtrusive C#
Over a decade ago, web engineers introduced the concept of unobtrusive JavaScript. which was mainly around the idea that a web application should have it's CSS, HTML and JavaScript code all separated in their own files without one of them having to be using in the other's files.
This earlier concept has changed a lot since then, web applications have evolved dramatically and it seemed that this concept has become less of a priority in some populator frameworks.
PrettyBlazor attempts to bring this idea back, as it makes the code consumption of engineers' cognitive resources much lesser and more pleasant to read through and detect any issues in any if any.
The idea of Unobtrusive C# is to mainly ensure that C# code stays within `.cs` files and it shall be it's only responsiblity to describe the actions of UI components or the events that follow within.
And that's why PrettyBlazor was made, to litterally make developing Blazor applications prettier, easier to understand and faster to implement.

Here's a more combined example of PrettyBlazor:
```html
<Iterations Items="Numbers">
  <Condition Evaluation="@(context%2 == 0)">
    <Match>
      <p>It's true!</p>
    </Match>
    <NotMatch>
      <p>It's false!</p>
    </NotMatch>
  </Condition>
</Iterations>
```

The equivelant of writing the same statement in Blazor today would be:

```html
@foreach (int number in Numbers)
{
    if (number % 2 == 0)
    {
        <p>It's true!</p>
    }
    else
    {
        <p>It's false!</p>
    }
}
```
C# mixed with html - which can become quite problematic from a readability, maintenance and performance perspectives when used in a large scale application - no matter how simpler you try to make the system components to be.

## 🌟 New in PrettyBlazor: `<Switch>`, `<SwitchCase>`, and `<SwitchDefault>`

PrettyBlazor now includes declarative components to replace `@switch` statements in markup. These components allow rendering different UI fragments based on a value—without C# logic interleaved in your `.razor` files.

### Example
```razor
<Switch T="AuthorizedState" Value="ComponentState">
    <SwitchCase T="AuthorizedState" When="AuthorizedState.Loading">
        <p>Loading...</p>
    </SwitchCase>

    <SwitchCase T="AuthorizedState" When="AuthorizedState.Authorized">
        <p>Welcome back!</p>
    </SwitchCase>

    <SwitchCase T="AuthorizedState" When="AuthorizedState.Error">
        <p>Something went wrong.</p>
    </SwitchCase>

    <SwitchDefault>
        <p>Unknown state.</p>
    </SwitchDefault>
</Switch>
```
This replaces traditional Blazor syntax like:
```razor
@switch (ComponentState)
{
    case AuthorizedState.Loading:
        <p>Loading...</p>
        break;
    case AuthorizedState.Authorized:
        <p>Welcome back!</p>
        break;
    case AuthorizedState.Error:
        <p>Something went wrong.</p>
        break;
    default:
        <p>Unknown state.</p>
        break;
}
```

## Installation

Command Line (execeute this in the directory your project file is located)
```
dotnet add package PrettyBlazor
```

In your Component (or _Imports.cs)
```cshtml
@using PrettyBlazor
```

## Challenges and Dreams
PrettyBlazor is only a good start to a full unobtrusive C# routines in a Blazor application, the true issue here still stands with some of the C# code even if it's just a reference invading the space of the markup instead of gracefully handling the non-blazor or js availability with a graceful failure for the HTML body to load without having to add any additional logic.
The dream state is to allow C# to find and attach events or property values to Blazor components from the back-end without having to have any references whatsoever on the front-end.

here's a video introduction to this library:

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/-NW2rp1J1ps/0.jpg)](https://www.youtube.com/watch?v=-NW2rp1J1ps)


If you have any suggestions, comments or questions, please feel free to contact me on:
<br />
Twitter: @hassanrezkhabib
<br />
LinkedIn: hassanrezkhabib
<br />
E-Mail: hassanhabib@live.com
<br />
