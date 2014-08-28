$.fn.gallery = function () {
    var $this = $(this),
        $parentNode = $this,
        GALLERY_COLUMNS,
        $galleryListNode = $this.find('.gallery-list'),
        $selectedNode = $this.find('.selected'),
        isSelectedHidden;

    function getPreviousImage($currentImage) {
        var $previousImage;
        $previousImage = $currentImage.prev('.image-container');

        if ($previousImage.length === 0) {
            $previousImage = $galleryListNode
                .find(
                    $('.image-container')
                        .last()
                );
        }

        return $previousImage.children('img');
    }

    function getNextImage($currentImage) {
        var $nextImage;

        $nextImage = $currentImage.next('.image-container');

        if ($nextImage.length === 0) {
            $nextImage = $galleryListNode
                .find(
                    $('.image-container')
                        .first()
                );
        }

        return $nextImage.children('img');
    }

    function refreshSelectedImages($selectedNode, $prevImg, $currImg, $nextImg) {
        $selectedNode
            .find($('.next-image')
                .children('img').attr('src', $nextImg.attr('src'))
            );
        $selectedNode
            .find($('.current-image')
                .children('img').attr('src', $currImg.attr('src'))
            );

        $selectedNode
            .find(
                $('.previous-image')
                    .children('img').attr('src', $prevImg.attr('src'))
            );
    }

    if (!arguments[0]) {
        GALLERY_COLUMNS = 4;
    } else {
        GALLERY_COLUMNS = arguments[0];
    }

    $this.addClass('gallery');

    $selectedNode.hide();
    isSelectedHidden = true;

    $this.width(GALLERY_COLUMNS * 250 + (GALLERY_COLUMNS * 10));

    var $allImages = $galleryListNode.find('.image-container');

    for (var i = 0; i < $allImages.length; i++) {
        var $currentItem = $($allImages[i]);

        $currentItem.on('click', function (ev) {
            if (isSelectedHidden) {
                var $curr = $(this);
                var $prevImg = getPreviousImage($curr);
                var $currImg = $curr.children('img');
                var $nextImg = getNextImage($curr);

                isSelectedHidden = false;
                $galleryListNode
                    .addClass('disabled-background')
                    .addClass('blurred');                

                $selectedNode
                    .find(
                        $('.previous-image')
                            .children('img').attr('src', $prevImg.attr('src'))
                            .on('click', function (ev) {
                                $nextImg = $currImg;
                                $currImg = $prevImg;
                                $prevImg = getPreviousImage($currImg.parent());

                                refreshSelectedImages($selectedNode, $prevImg, $currImg, $nextImg);
                            })
                    );

                $selectedNode
                    .find($('.current-image')
                        .children('img').attr('src', $currImg.attr('src'))
                        .on('click', function (ev) {
                            $galleryListNode
                                .removeClass('disabled-background')
                                .removeClass('blurred');
                            
                            $selectedNode.hide();
                            isSelectedHidden = true;
                        })
                    );
                $selectedNode
                    .find($('.next-image')
                        .children('img').attr('src', $nextImg.attr('src'))
                        .on('click', function (ev) {
                            $prevImg = $currImg;
                            $currImg = $nextImg;
                            $nextImg = getNextImage($currImg.parent());

                            refreshSelectedImages($selectedNode, $prevImg, $currImg, $nextImg);
                        })
                    );

                $selectedNode.show();
                isSelectedHidden = false;
            }            
        });
    }
};