using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Element;
using All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Visitor.DocumentsVisitor
{
    public class VisitorClient
    {
        public static void main()
        {
            var wordDoc = new WordDocument { Content = "Word content" };
            var pdfDoc = new PDFDocument { Content = "PDF content" };

            var printer = new DocumentPrinter();
            var saver = new DocumentSaver();

            wordDoc.Accept(saver);
            wordDoc.Accept(printer);

            pdfDoc.Accept(saver);
            pdfDoc.Accept(printer);
        }
    }
}
/*
When NOT to Use:
If the object structure changes frequently, 
Visitor becomes cumbersome since each class needs to implement Accept.

When behavior is unlikely to change or isn't 
complex, a straightforward method call may suffice.



Real-World Examples:
Compilers:

Parsing and traversing an Abstract Syntax Tree (AST) with different visitors for type checking, code generation, or optimization.
Graphics Editors:

Applying different operations like resizing, rendering, or exporting on shapes (Circle, Rectangle) without modifying the shape classes.
Business Applications:

Generating reports (e.g., XML, JSON) from a set of data objects without modifying their structure.
Game Development:

Handling interactions between game entities like players, NPCs, and environment objects.


When to Use :
1. Adding New Behavior Without Changing Existing Code
Instead of modifying each class (Knight, Dragon), new behaviors can be added by creating a new Visitor.
Example: Adding different operations like logging, report generation, or AI interaction for the same set of classes.


2. Applying Multiple Operations on an Object Structure
If you need to perform multiple operations (e.g., rendering, validation) on the same objects, 
the Visitor pattern keeps these operations separate from the objects themselves.

4. Double Dispatch
Solves the double dispatch problem by dynamically determining the interaction 
logic based on both object types (e.g., Knight attacking a Dragon).


5. Extensibility
New visitors can be added to introduce new functionality without altering 
the original classes, adhering to the Open/Closed Principle.


 */