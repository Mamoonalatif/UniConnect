window.voiceSearch = {
    recognition: null,
    recognitionTimeout: null,
    dotNetRef: null,

    startRecognition: function (dotNetRef) {
        if (!('webkitSpeechRecognition' in window)) {
            alert("Speech Recognition is not supported by this browser.");
            return;
        }

        // If already running, stop first
        if (this.recognition) {
            this.stopRecognition();
        }

        this.dotNetRef = dotNetRef;
        const recognition = new webkitSpeechRecognition();
        recognition.continuous = false;
        recognition.interimResults = false;
        recognition.lang = 'en-US';

        recognition.onresult = function (event) {
            if (event.results.length > 0) {
                const transcript = event.results[0][0].transcript;
                dotNetRef.invokeMethodAsync("SetSearchTerm", transcript);
            }
            window.voiceSearch.stopRecognition();
        };

        recognition.onerror = function (event) {
            console.error("Speech recognition error:", event.error);
            window.voiceSearch.stopRecognition();
        };

        recognition.onstart = function () {
            document.querySelector(".mic-button")?.classList.add("listening");
        };

        recognition.onend = function () {
            document.querySelector(".mic-button")?.classList.remove("listening");
            clearTimeout(window.voiceSearch.recognitionTimeout);
            window.voiceSearch.recognition = null;

            if (window.voiceSearch.dotNetRef) {
                window.voiceSearch.dotNetRef.invokeMethodAsync("OnRecognitionEnded");
            }
        };

        navigator.mediaDevices.getUserMedia({ audio: true })
            .then(() => {
                recognition.start();
                this.recognition = recognition;
                this.recognitionTimeout = setTimeout(() => {
                    this.stopRecognition();
                }, 10000);
            })
            .catch(err => {
                alert("Microphone permission is required for voice search.");
                console.error("Permission error:", err);
                if (this.dotNetRef) {
                    this.dotNetRef.invokeMethodAsync("OnRecognitionEnded");
                }
            });
    },

    stopRecognition: function () {
        if (this.recognition) {
            try {
                this.recognition.stop();
            } catch (e) {
                console.warn("Recognition already stopped:", e);
            }
        }
        clearTimeout(this.recognitionTimeout);
        this.recognition = null;
    }
};
