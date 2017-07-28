package helloworld;


import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.function.Function;

import helloworldcomponent.HelloWorldData;

public class Program
{

  public static void main(String[] args) throws Exception
  {
    HelloWorldData newObject = new HelloWorldData("Hello World");

    // Method use to access property value
    System.out.println(newObject.getName());

    // Direct access to public property
    // NONE in Java

    // "delegate" keyword example
    // create delegate instances for multi cast
    Function<Integer, Integer> nc;
    
    Function<Integer, Integer> nc1 = Program::AddNum;
    Function<Integer, Integer> nc2 = Program::MultNum;
    
    nc = nc1.andThen(nc2);

    // calling the methods using the delegate objects
    nc1.apply(25);
    System.out.format("\nValue of Num: %d", getNum());
    nc2.apply(5);
    System.out.format("\nValue of Num: %d", getNum());

    // calling multi cast
    nc.apply(5);
    nc.apply(10)
    System.out.format("\nValue of Num: %d", getNum());

    // lambda expression
    Function<Integer, Integer> ncAddWithLambda = (x) -> { x += x;  return x;  };
    System.out.format("\nValue of ncAddWithLambda: %d\n",  ncAddWithLambda.apply(10));

    // "using" keyword example
    System.out.println(getContentFromFile("C:\\Mufaddal\\DotNetvsJAVA\\Examples\\TextDemo.txt"));

  }

  static int num = 10;

  public static int AddNum(int p)
  {
    num += p;
    return num;
  }

  public static int MultNum(int q)
  {
    num *= q;
    return num;
  }

  public static int getNum()
  {
    return num;
  }
  
  public static String getContentFromFile(String fileName) throws IOException
  {
    String line = "";
    StringBuilder fileBuilder = new StringBuilder();

    try (BufferedReader file = new BufferedReader(new FileReader(fileName)))
    {
      while ((line = file.readLine()) != null)
      {
        if (line != null && !line.isEmpty())
        {
          fileBuilder.append(line);
          fileBuilder.append(System.getProperty("line.separator"));
        }
      }
    }

    return fileBuilder.toString();
  }

}
