document.addEventListener('DOMContentLoaded', function () {
  var text = document.querySelector('.text');
  var newText = 'playing football.';

  setTimeout(function () {
    text.innerHTML = "Hello"
    text.style.animation = 'typing 3s steps(19), cursor .4s step-end infinite alternate-reverse, deleting 2s steps(19) 5s forwards';
  }, 7000); // Adjust the timing according to your need
});