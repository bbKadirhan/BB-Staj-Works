var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function() {

    this.classList.toggle("active");

    var panel = this.nextElementSibling;
    if (panel.style.display === "block") {
      panel.style.display = "none";
    } else {
      panel.style.display = "block";
    }
  });
}



function showToast() {
    const toast = document.getElementById("toastNotification");
        
    toast.classList.add("toast-visible");
        
    setTimeout(function(){ 
         toast.classList.remove("toast-visible"); 
    }, 3000);
}


function validateAndNotify(event) {
    event.preventDefault(); 
    const form = document.querySelector('.application-form');

    showToast();
    form.reset();
    return true;
}