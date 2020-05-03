function check() {

    var question1 = document.quiz2.question1.value;
    var question2 = document.quiz2.question2.value;
    var question3 = document.quiz2.question3.value;
    var correct = 0;


    if (question1 == "joey") {
        correct++;
    }
    if (question2 == "Hartford") {
        correct++;
    }
    if (question3 == "Albany") {
        correct++;
    }

    var pictures = ['/Content/win.gif', '/Content/meh.jpeg', '/Content/lose.gif'];
    var messages = ["Great job!", "That's just okay", "You really need to do better"];
    var score;

    if (correct == 0) {
        score = 2;
    }

    if (correct > 0 && correct < 3) {
        score = 1;
    }

    if (correct == 3) {
        score = 0;
    }

    document.getElementById("after_submit1").style.visibility = "visible";

    document.getElementById("message1").innerHTML = messages[score];
    document.getElementById("number_correct1").innerHTML = "You got " + correct + " correct.";
    document.getElementById("picture1").src = pictures[score];
}