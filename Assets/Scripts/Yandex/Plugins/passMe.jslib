mergeInto(LibraryManager.library, {

  EnableCrossLevelAdv: function () {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage("GameManager", "LoadScene");
          console.log("-----closed------")
        },
        onError: function(error) {
          // some action on error
        }
        }
        })
  },

  ShowAdv: function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: function() {
          console.log('Video ad open.');
        },
        onRewarded: function() {
          console.log('Rewarded!');
        },
        onClose: function() {
          console.log('Video ad closed.');
        }, 
        onError: function() {
          console.log('Error while open video ad:', e);
        }
    }
})
  },
    
});