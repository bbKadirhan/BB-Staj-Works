document.addEventListener('DOMContentLoaded', function () {
  var text = document.getElementById("text")
  const words = ["Still in progress...", "This animation is cool!!", "Need more content...", "Typewriter effect :)"];
  let wordIndex = 0;
  function typeword() {
    let word = words[wordIndex];
    text.textContent = word;
    text.classList.remove("text");
    text.style.animation = "none"
    text.offsetHeight;
    text.style.animation = "typing 3s steps("+ word.length +"), cursor .4s step-end infinite alternate-reverse, deleting 2s steps("+ word.length +") 5s forwards";
    text.classList.add("text");
    setTimeout(() => {
      wordIndex = (wordIndex + 1) % words.length;
      typeword()
    }, 7000);
    text.classList.add("text")
  }
  typeword();
});