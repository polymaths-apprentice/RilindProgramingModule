# RilindProgramingModule
This repository has 2 solutions for user input/output , one in node.js the other in c# for the assignment 

On this read-me file, i will cover some of main point of comparison for both platforms

•••••• Language and enviroment ••••••

	C# is statically typed (with int, strings), compiled language( to machine code ). Ndersa node.js is event-driven, async runtime build on chrome's V8 machine
	
	C# has a wide range of applications, from building desktop apps, web apps and games
	
	Node.js since osht extension of javascript me v8, popular for server-side and network app
			
			Eventho the language of javascript of node.js has started seeing light edhe ne other fields
			
			

	C# follows OOP like classes, structs, inherintance and strong type checking (follow more on memory for types)
	
	Node.js based on javascript is more event-driven programming, with support on callbacks, promises and async/await syntacs. The flow of execution of Node.js programs is that its single threaded, which "re-directs" the execution with the support of qka thash, callbacks, promises and async/await

__________________________________________________________________________________________________________________

•••••• Exception handling ••••••

	Ne c# exceptions are "objects" that represent errors. Done via try-catch blocks, and when they are caught we can take some actions
	
		Unhandled exceptions lead to termination. The .NET runtime automatically performs memory clean up for objects that are no longer reachable
		
		
	Js also supports exception handling with try-catch. 
	
	Unhandled exceptions in node.js cause the program to terminate. Node.js employs garbage collector to automatically release memory occupied by unreferenced objects
	
  Since kto jon high-level languages, they don’t directly deal with it, but provide a level of abstraction

  c# interacts with hardware through API's, like system.io.namespace for input/output, and other API's for hardware related operations for accessing devices, sensors etc

  Node.js since osht build on js, and initially js was made for web, it provides with some modules and libraries to handle hardware interactions indirectly, like writing files, accessing db and such
__________________________________________________________________________________________________________________
•••••• User input and displaying output


	In c#, under system provides the console class which deals with input and output. 
	
	
	Since node.js is a non-blocking, meaning it tries to execute all the code meniher, and not stopping or trying to throw tjera ka the blocking operations. We have to provide a special module which makes it blocking, and waiting for the user input. We have to implement a module and install with NPM, and then we have to create an interface with that module, which 
	
  As for dealing with invalid inputs, we either can handle them via exceptions, or try to work around them with if checks


__________________________________________________________________________________________________________________

  •••••• Handling arrays/list of questions


  c#
      Arrays and lists are pre-made data types in c#. The arrays are just bunch of data grouped together.

      In c# to declare a simple array we use the following syntax

          dataType[] arrayName = new dataType[length];

          int[] numbers = new int[5];

      And this in memory looks something like this :

        The memory alocated for the array depends on 2 factors

          1. Its size
          2. The data type

        And in our case, since we have 5 integers, the memory is alocated for 5 intigers(which take 4 byte for int), and some "overhead" which is more related to how memory knows that they are connected, and to be index

        The predefined space just alocates memory for these data, and whenever we fill them with real values, it makes sure qe that alocation can be performed


          § When adding a new element to an array within its pre-defined length, the memory allocation of the array remains unchanged.
          § When adding a new element beyond the pre-defined length, you need to resize the array by creating a new array with a larger size and copying the existing elements.


        So in terms of speed and optimizations, arrays with pre-defined values are quite good. But they would take a lot of memory to add a new element more than what we originally thought


      Ndersa arrayLists are a new way of dealing with data that we are not sure of what format and length


        They are "dynamic-sized" collections that store elements, and has a few build in methods of adding and removing elements

          It also works with objects. 

          And a rule of thumb is that Lists implement the strategy of re-sizing to handle the memory.

            If we create a new list, it creates a default capacity of 0 and always doubles kur mrrin there.


        Now lets see how that would look under the hood in memory


          1. Initial allocation : When we create a new list, it internally allocates the aray with default capacity. Lets assume the memory adress is XX11
          2. New elements and memory re-allocation : When the default capacity is met, it allocates a new memory with double of the previous size, lets say on adress YY22.
              And it copies the existing elements from XX11 to YY22
          3. Continious storage: By copying elements for every expansion of the list, it makes sure that elements remain relatively close to each other. Which is a good thing for access and traversal of elements
          4. Adjecent memory availability : If the memory ngjit nuk o available due to allocations or fragmentations, the class requests a continious block of memory

        And the List<T> has its own internal bookkeeping to keep track of memory locations, and references for is own elements



  Javascript


      In node.js arrays are dynamic and grow/shrink according the elements

        The memory for these bad boys is handled by the engine, and I think that different engines do it differently. V8 might approach ma ndryshe se spiderMonkey.


        The v8 engine works bit differently from c#


        The arrays here are "packed" meaning they store consecutive elements without any gasps. 

          If we don’t specify the length, it usually creates 4 to 8 elements and grows as elements are added.
          When a new element is added, v8 automatically resizes the array by allocating new larget chunk of memory

        Overallocation involves allocating more memory than is currently needed for the array. This allows for efficient appending of new elements without triggering frequent resizes.

        When an array in Node.js doubles in size due to a resize operation, the previous memory block allocated for the array is no longer needed and becomes garbage

        The V8 engine employs automatic garbage collection to manage memory

          The garbage collection process in V8 typically involves the following steps:

          Marking: The garbage collector traverses the object graph, starting from the root objects (global objects, stack variables, etc.), marking all objects that are still reachable.

          Sweeping: After marking, the garbage collector sweeps through the heap, identifying and freeing memory occupied by objects that are not marked as reachable. This includes the memory previously allocated for the smaller arr
	
__________________________________________________________________________________________________________________
  
•••••• Handling async functions


  in node.js since is a single threaded, it implements async operations implementing non-blocking operations. In c# in recent developments we also got that.



  However if these were not the case, we have a few ways to workaround.


    Callbacks : A code which is said to execute somewhere else, and to not stop the flow of code

      Both implement it. C# with recent developments

    Promises :

      A node.js thing for async programing. Is a code which is executed and returns a "promise" or a value that we either get back or we get an error

    Threads and paralelism

      More of a c# thing

    Libraries :

      Node.js has few of them such as rxjs, edhe c# aswell


  In our case in c# we implement a stopWatch

  When you call timer.Start(), it starts the stopwatch and begins measuring elapsed time from that point onwards. It does not block the code execution; instead, it starts a background process to track the passage of time
__________________________________________________________________________________________________________________


•••••• Handling errors here

  C#:

  C# provides exception handling mechanism using try-catch blocks. 

    • You enclose the code that might raise an exception within a try block.
    • If an exception occurs within the try block, the execution is immediately transferred to the catch block.
    • In the catch block, you can specify the type of exception you want to catch, and corresponding actions to handle the exception.
    • Optionally, you can include multiple catch blocks to handle different types of exceptions.
    • After executing the catch block, the program continues its execution unless further exceptions are thrown.

  We can also make our custom exceptions .
    And we have the finally() which executes no matter what kind of exception we have


  Node.js:

      1. In Node.js, error handling is typically done using callback functions or promises. Here's how it works:
      2. When working with asynchronous operations that may result in an error, you pass a callback function or use promise to handle the success and error scenarios.
      3. If an error occurs during the execution of an asynchronous operation, the error is passed as the first argument to the callback function or the catch block of a promise.
      4. You can then handle the error by checking its type, logging error messages, or taking appropriate actions.

    And node.js handles it tu e throw an error on  a function with a callback form, and then when we call that function we can chain what we do with it with then(), and potentially throw the error there

      Node.js also implements try-catch but mostly done qashtu then().catch()


    And as siide note on why we should be weary on exceptions

      1. When an exception occurs, in c# an exception object is created and contains data about it, which adds to the memory
      2. When an exception is thrown, the runtime needs to "unwind" the callstack and during that time it has to dealocate variables, clean up resources which can be heavy when there is a deep call stack
      3. The exception handling mechanism when trying to find an appropriate catch block. Tries to find the right one, and when there are many te lidhta, ateher bohet pak heavy
      4. Performance on cpu, se do pun u kry already and duhet si a "recovery" me bo

    And you might be asking this question  : 
    on the stack unwinding, does that thing still happen eventhough we did catch the exception? Lets assume we have a functionX() and there are some variables created, some methods executed and so on. At the very bottom, we throw an exception. What happens then


      • Suppose we have a function functionX() with variables, method executions, and other code.

      • At some point within functionX(), an exception is thrown using the throw statement.

      • The runtime starts unwinding the call stack, searching for an appropriate catch block to handle the exception.

      • If a matching catch block is found within functionX() or in any calling functions, the runtime transfers control to that catch block. The catch block executes and performs the necessary exception handling operations.

      • After the catch block finishes executing, the program flow continues from the point immediately after the catch block. The call stack is not completely unwound


