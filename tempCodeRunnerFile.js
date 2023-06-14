function startQuiz() {
  const questions = [
    new Question(
      "Question 1: What is the capital of France?",
      "Hint: It's known as the 'City of Love'.",
      "Paris",
      String
    ),
    new Question(
      "Question 2: Who painted the Mona Lisa?",
      "Hint: He was an Italian artist and polymath.",
      "Da Vinci",
      String
    ),
    new Question(
      "Question 3: How many millimeters are in a meter?",
      "Hint: As many as there meters in a kilometer.",
      "1000",
      Number
    ),
  ];

  const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
  });

  console.log("Welcome to the Polymath Quiz Who wants to be a millionaire!");
  const totalQuestions = questions.length;
  const quizTimeInSeconds = 60;
  const timer = new Date();
  rl.question("Please enter your name: ", (userName) => {
    console.log(`Hello, ${userName}! Let's start the quiz.`);

    let score = 0;

    function askQuestion(index) {
      const question = questions[index];
      let hintDisplayed = false;

      console.log(question.text);
      rl.question("Your answer: ", (userAnswer) => {
        if (!userAnswer.trim()) {
          console.log("Invalid input! Please provide an answer.");
          askQuestion(index); // Retry the same question
          return;
        }

        if (question.answerType === Number) {
          if (Number.isNaN()) {
            console.log("Invalid input! Please provide a numeric answer.");
            askQuestion(index); // Retry the same question
            return;
          }
        }

        if (userAnswer.trim().toLowerCase() === question.answer.toLowerCase()) {
          console.log("Correct!");
          score++;
        } else {
          console.log("Incorrect!");
        }

        if (index === totalQuestions - 1) {
          console.log(`Quiz completed! Your score: ${score}/${totalQuestions}`);
          console.log(
            `You took around ${
              (new Date() - timer) / 1000
            } seconds to finish the quiz.`
          );
          rl.close();
        } else {
          askQuestion(index + 1); // Ask the next question
        }
      });

      const hintTimeout = setTimeout(() => {
        if (!hintDisplayed) {
          console.log(question.hint);
          hintDisplayed = true;
        }
      }, 5000);

      //Line is refering to the readLine. Clear the timeout when we type something
      rl.on("line", () => {
        clearTimeout(hintTimeout);
      });
    }

    askQuestion(0);
  });

  // Throw an exception if the user took too long
  const timeout = setTimeout(() => {
    throw new Error("Time expired! Sorry, you didn't finish the quiz in time.");
  }, quizTimeInSeconds * 1000);

  //r1.on close means when is closed
  rl.on("close", () => {
    clearTimeout(timeout);
  });
}