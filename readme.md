<a href="https://www.questpdf.com/">
  <img src="https://github.com/QuestPDF/example-invoice/raw/main/images/logo.svg" width="400px"> 
</a>

## Overview

1) **Rely on solid fundamentals** - This library is created specifically for designing and arranging document layouts, with full paging support.  Alternative solutions, such as HTML-based converters, are not designed for this purpose and therefore are often unpredictable and do not produce desired results.

2) **Work with organized self-explanatory code** - The entire process of implementing PDF document, takes place in your code. Free yourself from slow visual designers and strange technological limitations. Follow simple yet highly effective approaches to create maintainable, high-quality code.

3) **Compose simple components into complex documents** - Do you remember the feeling when your code just works? When your ideas are becoming real without any effort? Working with simple, easy to understand, self-explanatory and highly composable layout elements is the key here!

4) **Create and reuse components** - Feel no fear of complex documents! Create custom, reusable components and divide the document's layout into easy to maintain pieces. Inject data to customize content and use slots to enhance composability. Decide how complex approaches your solution needs and follow the best path.

5) **Prototype with ease** - We understand that document generation is often tricky and require multiple iterations. The library offers additional prototyping tools such as random text generator or image placeholder element. By following best practices, you can develop a document without having data.

6) **Enjoy fast PDF generation** - QuestPDF is created upon SkiaSharp, a well-known graphical library, and converts your data into PDF documents. It offers a highly optimized layouting engine capable of generating over 1000 PDF files per minute per core. The entire process is thread-safe.

## Support QuestPDF

All great frameworks and libraries started from zero. Please help us to make QuestPDF a commonly known library and an obvious choice in case of generating PDF documents. It can be as easy as:
- Giving this repository a star ⭐ so more people will know about it,
- Observing 🤩 the library to know about each new realease,
- Trying our sample project to see how easy it is to create an invoice 📊,
- Sharing your thoughts 💬 with us and your colleagues,
- Simply using it 👨‍💻 and suggesting new features,
- Creating new features 🆕 for everybody.

## Installation

The library is available as a nuget package. You can install it as any other nuget package from your IDE, try to search by `QuestPDF`. You can find package details [on this webpage](https://www.nuget.org/packages/QuestPDF/).

<a href="https://www.nuget.org/packages/QuestPDF/">
  <img src="https://github.com/QuestPDF/example-invoice/raw/main/images/nuget.svg" width="200px">  
</a>

## Documentation

1. [Release notes and roadmap](https://www.questpdf.com/documentation/releases.html) - everything that is planned for future library iterations, description of new features and information about potential breaking changes.
2. [Getting started tutorial](https://www.questpdf.com/documentation/getting-started.html) - a short and easy to follow tutorial showing how to design an invoice document under 200 lines of code.
3. [API Reference](https://www.questpdf.com/documentation/api-reference.html) - a detailed description of behavior of all available components and how to use them with C# Fluent API.
4. [Patterns and practices](https://www.questpdf.com/documentation/patterns-and-practices.html#document-metadata) - everything that may help you designing great reports and reusable code that is easy to maintain.

## Example invoice

Do you believe that creating a complete invoice document can take less than 200 lines of code? We have prepared for you a step-by-step instruction that shows every detail of this implementation and describes the best patterns and practices.

For tutorial, documentation and API reference, please visit [the QuestPDF documentation](https://www.questpdf.com/documentation/getting-started.html).

<a href="https://github.com/QuestPDF/example-invoice">
  <img src="https://github.com/QuestPDF/example-invoice/raw/main/images/invoice.png" width="595px">
</a>

Here you can find an example code showing how easy is to write and understand the fluent API:

```csharp
public void Compose(IDocumentContainer container)
{               
    container
        .Page(page =>
        {
            page.MarginVertical(60);
            page.MarginHorizontal(40);
            
            page.Size(PageSizes.A4);
                
            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().AlignCenter().PageNumber();
        });
}

void ComposeHeader(IContainer container)
{
    container.Row(row =>
    {
        row.RelativeColumn().Stack(stack =>
        {
            stack.Item().Text($"Invoice #{Model.InvoiceNumber}", TextStyle.Default.Size(20).Bold());
            stack.Item().Text($"Issue date: {Model.IssueDate:d}");
            stack.Item().Text($"Due date: {Model.DueDate:d}");
        });
        
        row.ConstantColumn(100).Height(50).Placeholder();
    });
}

// code describing content
```
