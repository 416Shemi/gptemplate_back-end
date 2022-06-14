window.onscroll = () => {
    let nav = document.querySelector("nav");
    if (window.pageYOffset >= 100) {
        nav.classList.add("bg-nav");
    }
    else {
        nav.classList.remove("bg-nav");
    }
}
// let serviceItems = document.querySelectorAll("#services .row .col-md-4")
// let currentItem = 0
// serviceItems.forEach(function (a) {
//     currentItem++;
//     if (currentItem % 3 != 0 && a.nextElementSibling) {
//         a.nextElementSibling.style.left = 425 * currentItem + "px"
//         a.nextElementSibling.style.height = a.nextElementSibling.children[0].clientHeight + "px"
//     }
//     else {
//         currentItem = 0;
//         a.style.left = 425 * currentItem + "px"
//         a.style.height = a.children[0].clientHeight + "px"
//     }
// })