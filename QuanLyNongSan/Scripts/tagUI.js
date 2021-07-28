// ________________Tag-UI______________________

const detailItems = document.querySelectorAll(".detail-content-item");
const detailTexts = document.querySelectorAll(".detail-text-item");
const detailLine = document.querySelector(".detail-line");

detailLine.style.left = document.querySelector('.detail-content-item.active').offsetLeft + 12 + 'px';
detailLine.style.width = document.querySelector('.detail-content-item.active').offsetWidth + 'px';


detailItems.forEach(function(detailItem, index) {
    var detailText = detailTexts[index]
    detailItem.onclick = function() {

        document.querySelector('.detail-content-item.active').classList.remove('active')
        document.querySelector('.detail-text-item.active').classList.remove('active')

        this.classList.add('active')
        detailText.classList.add('active')

        detailLine.style.left = document.querySelector('.detail-content-item.active').offsetLeft + 12 + 'px'
        detailLine.style.width = document.querySelector('.detail-content-item.active').offsetWidth + 'px'

    }

});