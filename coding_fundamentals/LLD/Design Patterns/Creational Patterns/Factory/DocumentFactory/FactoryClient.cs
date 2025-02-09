using All.Design.Patterns.Creational_Patterns.Factory.AbstractProduct;
using All.Design.Patterns.Creational_Patterns.Factory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Creational_Patterns.Factory
{
    public class FactoryClient
    {
        public static void main()
        {
            DocumentFactory factory = new WordDocumentFactory();
            IDocument document = factory.CreateDocument();
            document.Open();
            document.Save();
            document.Close();

            factory = new PdfDocumentFactory();
            document = factory.CreateDocument();
            document.Open();
            document.Save();
            document.Close();
        }
    }
}


/*
 Different ways to implement the factories :
1.Switch case in factory class
public class DocumentFactory
{
    public IDocument CreateDocument(string type)
    {
        if (type == "Word")
            return new WordDocument();
        else if (type == "PDF")
            return new PdfDocument();
        else
            throw new ArgumentException("Invalid document type");
    }
}

2.Keep Dictionary of type and objects and give one method to add in this dictionary and then access it whenever required!
public class DocumentFactory
{
    private readonly Dictionary<string, Func<IDocument>> _documentCreators;

    public DocumentFactory()
    {
        _documentCreators = new Dictionary<string, Func<IDocument>>
        {
            { "Word", () => new WordDocument() },
            { "PDF", () => new PdfDocument() }
            // Add more document types here
        };
    }

    public void RegisterDocumentType(string type, Func<IDocument> creator)
    {
        _documentCreators[type] = creator;
    }

    public IDocument CreateDocument(string type)
    {
        if (_documentCreators.TryGetValue(type, out var creator))
        {
            return creator();
        }

        throw new ArgumentException($"Document type '{type}' is not recognized");
    }
}


3.Reflection
public class DocumentFactory
{
    public IDocument CreateDocument(string type)
    {
        // Construct the fully qualified class name (assumes the classes are in the same namespace)
        string className = $"{this.GetType().Namespace}.{type}Document";

        // Load the type dynamically
        Type documentType = Type.GetType(className);

        if (documentType == null)
        {
            throw new ArgumentException($"Document type '{type}' is not recognized");
        }

        // Create an instance of the type
        return (IDocument)Activator.CreateInstance(documentType);
    }
}

4. Dependency Injection :
public interface IDocumentFactory
{
    IDocument CreateDocument();
}

public class WordDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

public class PdfDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

// Add more factories as needed


public class DocumentFactory
{
    private readonly Dictionary<string, IDocumentFactory> _factories;

    public DocumentFactory(Dictionary<string, IDocumentFactory> factories)
    {
        _factories = factories;
    }

    public IDocument CreateDocument(string type)
    {
        if (_factories.TryGetValue(type, out var factory))
        {
            return factory.CreateDocument();
        }

        throw new ArgumentException($"Document type '{type}' is not recognized");
    }
}


4.1 : Keeping single instance of IDocumentFactory :
public class DocumentFactory
{
    private IDocumentFactory _documentFactory;

    // Constructor that takes a factory as a parameter
    public DocumentFactory(IDocumentFactory documentFactory)
    {
        _documentFactory = documentFactory;
    }

    public IDocument CreateDocument()
    {
        return _documentFactory.CreateDocument();
    }
}

Diff between strategy and factory is :
- Strategy DP has Context class which makes strategy to execute method of a particular class assigned by client!
- In the case of Factory pattern, client interacts with the factory and factory creates that instance

Strategy Pattern: Encapsulates interchangeable algorithms or behaviors, allowing dynamic selection at runtime. Focus: Behavioral logic.
Factory Pattern: Centralizes object creation, delegating the instantiation process. Focus: Object creation.

public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(decimal amount)
    {
        _paymentStrategy.Pay(amount);
    }
}


//
class Program
{
    static void Main(string[] args)
    {
        // Payment using Credit Card
        PaymentContext paymentContext = new PaymentContext(new CreditCardPayment());
        paymentContext.ProcessPayment(150.75m);

        // Switching to PayPal payment
        paymentContext.SetPaymentStrategy(new PayPalPayment());
        paymentContext.ProcessPayment(89.99m);

        // Switching to Cryptocurrency payment
        paymentContext.SetPaymentStrategy(new CryptoPayment());
        paymentContext.ProcessPayment(200.00m);
    }
}


 */