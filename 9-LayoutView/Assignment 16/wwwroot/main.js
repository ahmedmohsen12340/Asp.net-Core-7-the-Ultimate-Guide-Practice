let temp = document.querySelectorAll(".temp");
let cards = document.querySelectorAll(".card");

for (let i = 0; i < temp.length; i++)
{
    if (+temp[i].innerHTML < 44) {
        cards[i].classList.add("blue");
    }
    else if (+temp[i].innerHTML >= 44 && +temp[i].innerHTML <= 74) {
        cards[i].classList.add("yellow");
    }
    else
    {
        cards[i].classList.add("red");
    }
}