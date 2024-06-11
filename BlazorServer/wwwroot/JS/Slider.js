console.log("Starting slider.js");


window.Blazor = window.Blazor || {};
window.Blazor.init_slider =  function () {
    const sliderContainers = document.querySelectorAll(".slider");
    console.log("Start init slider");

    sliderContainers.forEach(slider => {
        const slides = slider.querySelectorAll(".img-fluid");
        const totalSlides = slides.length;
        let currentIndex = 0;

        function updateSlider() {
            const newTransform = `translateX(-${currentIndex * 50}%)`;
            slider.querySelector(".slides").style.transform = newTransform;
        }

        slider.querySelector(".prev").addEventListener("click", function () {
            currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
            updateSlider();
        });

        slider.querySelector(".next").addEventListener("click", function () {
            currentIndex = (currentIndex + 1) % totalSlides;
            updateSlider();
        });
    });
    console.log("000 finish");
};

