//Mostrar un boton para volver arriba
const backToTop = document.createElement('button');
backToTop.textContent="↑";
backToTop.className = "fixed bottom-4 right-4 bg-blue-600 text-white p-2 rounded hidden";
document.body.appendChild(backToTop);

window.addEventListener('scroll', () => {
    if(window.scrollY > 200){
        backToTop.classList.remove('hidden');
    } else {
        backToTop.classList.add('hidden');
    }
});

backToTop.addEventListener('click', () => {
    window.scrollTo({top: 0, behavior: "smooth"});
});