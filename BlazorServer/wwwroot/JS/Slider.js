//document.addEventListener('DOMContentLoaded', function () {
//    const sliderContainers = document.querySelectorAll(".slider");

//    sliderContainers.forEach(slider => {
//        const slides = slider.querySelectorAll(".img-fluid");
//        const totalSlides = slides.length;
//        let currentIndex = 0;

//        function updateSlider() {
//            const newTransform = `translateX(-${currentIndex * 100}%)`;
//            slider.querySelector(".slides").style.transform = newTransform;
//        }

//        slider.querySelector(".prev").addEventListener("click", function () {
//            currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
//            updateSlider();
//        });

//        slider.querySelector(".next").addEventListener("click", function () {
//            currentIndex = (currentIndex + 1) % totalSlides;
//            updateSlider();
//        });
//    });
//});

window.Blazor = window.Blazor || {};

window.Blazor.initializeSlider = function () {
    window.Blazor.sliders = [];  // Sicherstellen, dass sliders hier initialisiert wird.
    const sliderContainers = document.querySelectorAll(".slider");

    console.log("Slider initialization started.");

    sliderContainers.forEach((slider, index) => {
        let currentIndex = 0;
        const slides = slider.querySelectorAll(".img-fluid");
        const totalSlides = slides.length;

        window.Blazor.sliders[index] = {
            nextImage: function () {
                currentIndex = (currentIndex + 1) % totalSlides;
                updateSlider(slider, currentIndex);
            },
            prevImage: function () {
                currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
                updateSlider(slider, currentIndex);
            }
        };

        function updateSlider(slider, index) {
            const newTransform = `translateX(-${index * 100}%)`;
            slider.querySelector(".slides").style.transform = newTransform;
        }
    });

    console.log("Sliders initialized:", window.Blazor.sliders);
};

window.Blazor.nextImage = function (index) {
    const slider = window.Blazor.sliders[index];
    if (!slider) {
        console.error("Slider with index", index, "not found.");
        return;
    }
    slider.currentIndex = (slider.currentIndex + 1) % slider.totalSlides;
    slider.updateSlider();
};

window.Blazor.prevImage = function (index) {
    const slider = window.Blazor.sliders[index];
    if (!slider) {
        console.error("Slider with index", index, "not found.");
        return;
    }
    slider.currentIndex = (slider.currentIndex - 1 + slider.totalSlides) % slider.totalSlides;
    slider.updateSlider();
};



