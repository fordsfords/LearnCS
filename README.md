# LearnCS
Repo for me to experiment with c#.
Not interesting to anybody else.

<!-- mdtoc-start -->
&bull; [cs_tst](#cs_tst)  
&nbsp;&nbsp;&nbsp;&nbsp;&bull; [License](#license)  
&nbsp;&nbsp;&nbsp;&nbsp;&bull; [Introduction](#introduction)  
&nbsp;&nbsp;&nbsp;&nbsp;&bull; [References:](#references)  
&nbsp;&nbsp;&nbsp;&nbsp;&bull; [Type Inference](#type-inference)  
<!-- TOC created by '../mdtoc/mdtoc.pl README.md' (see https://github.com/fordsfords/mdtoc) -->
<!-- mdtoc-end -->

## License

Copyright 2024 Steven Ford http://geeky-boy.com and licensed
"public domain" style under
[CC0](http://creativecommons.org/publicdomain/zero/1.0/): 
![CC0](https://licensebuttons.net/p/zero/1.0/88x31.png "CC0")

To the extent possible under law, the contributors to this project have
waived all copyright and related or neighboring rights to this work.
In other words, you can use this code for any purpose without any
restrictions.  This work is published from: United States.  The project home
is https://github.com/fordsfords/cs_tst

To contact me, Steve Ford, project owner, you can find my email address
at http://geeky-boy.com.  Can't see it?  Keep looking.

## Introduction

This repo is just a sandbox for experimenting with C#.
I don't think anybody but me would be interested.
It certainly should not be seen as an example of good C# code.

## References

Entry into .NET 8 ref:
* https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-8.0

Case Conventions:
* https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/capitalization-conventions

Excerpt:
* DO use PascalCasing for all public member, type,
and namespace names consisting of multiple words.
  * Whay does it stipulate "consisting of multiple words"?
* DO use camelCasing for parameter names.
* DO NOT assume that all programming languages are case sensitive.
They are not. Names cannot differ by case alone.
  * Although I haven't seen it explicitly stated, it looks like local
variables are treated the same as input parameters - camelCase.

Conventions:
* https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

Excerpt:
* Use four spaces for indentation. Don't use tabs.
* Limit lines to 65 characters to enhance code readability on docs,
especially on mobile screens.
* Use the "Allman" style for braces:
open and closing brace its own new line.
Braces line up with current indentation level.
* Line breaks should occur before binary operators, if necessary.

Here's the MS .NET runtime team's conventions:
* https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md

Excerpt:
* Prefix internal and private instance fields with _, static fields with s_ and thread static fields with t_.
* When used on static fields, readonly should come after static (e.g. static readonly not readonly static).
* Public fields should be used sparingly and should use PascalCasing with no prefix when used.

Doc:
*  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
* Claims doxygen compat.

From https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
* By convention, C# programs use PascalCase for type names, namespaces,
and all public members. 

## Thoughts

### Tool Speed

For now I'm using command-line build tools ("dotnet build").
Boy, is it slow.
I'm used to C where I can just put the build right inside the test script
with no noticalble delay.

Now I'm sure that a good IDE would eliminate that delay,
and at some point I should transition to VS Code.

### Line Endings?

I'm used to converting everything to Unix line endings.
Experience suggests that dotnet tools handle it fine,
but even the Linux and Mac versions of the "dotnet" tool creates files with
cr/lf.

Not only that, but the "dotnet" tool creates the file to start with the
unicode [BOM](https://en.wikipedia.org/wiki/Byte_order_mark) sequence: EF BB BF
(in UTF-8).
According to Wikipedia, 
"The Unicode Standard permits the BOM in UTF-8,
but does not require or recommend its use."

### Non-Nullable Objects?

Why is it OK to have:
* string s = null;

But not:
* StringBuilder sb = null;

The latter gives a warning about it being non-nullable.

### Var and Target-Typed New

The Nutshell book says:
* "var" can decrease code readability when you can't deduce the type
purely by looking at the variable declaration.
  * Random r = new Random();  var x = r.Next();
* And yet, It seemed to think target-typed 'new' expressions are a good idea.
  * class foo { StringBuilder sb; public Foo() { sb = new("null"); }

It seems to me that these are two faces of the same coin.

### Switch Expressions

I have the same complaint with switch expressions as I have with Lambdas:
lack of readability.
It's like they're trying to make it Perl!
I see single-character variable names and no explanation of what is going on.

Make it a function, for goodness sake!
The function name itself serves as self-documentation.
