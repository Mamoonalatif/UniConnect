window.initializeChatBot = function () {
    const chatMessages = document.getElementById("chatMessages");
    const userInput = document.getElementById("userInput");
    const API_KEY = "AIzaSyBlPEvkmuYpvRtVO6QrdGP7rO2m1hSrJg8";

    function appendMessage(sender, text) {
        const message = document.createElement("div");
        message.className = `message ${sender}`;

        const avatar = document.createElement("div");
        avatar.className = "avatar";
        avatar.textContent = sender === "user" ? "🧑🏻" : "💡";

        const textEl = document.createElement("div");
        textEl.className = "text";

        if (sender === "bot") {
            textEl.innerHTML = marked.parse(text);
        } else {
            textEl.textContent = text;
        }

        message.appendChild(avatar);
        message.appendChild(textEl);
        chatMessages.appendChild(message);
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }

    function showTypingIndicator() {
        const typing = document.createElement("div");
        typing.className = "typing-indicator";
        typing.id = "typing";
        typing.textContent = "Bot is typing...";
        chatMessages.appendChild(typing);
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }

    function removeTypingIndicator() {
        const typing = document.getElementById("typing");
        if (typing) typing.remove();
    }
    async function sendMessage() {
        const message = userInput.value.trim();
        if (!message) return;

        appendMessage("user", message);
        userInput.value = "";
        showTypingIndicator();

        try {
            if (message.toLowerCase().startsWith("lost")) {
                // Call C# to fetch lost & found
                const result = await DotNet.invokeMethodAsync('UniConnect', 'GetLostFoundItems');
                removeTypingIndicator();
                appendMessage("bot", result);
                return;
            }

            if (message.toLowerCase().startsWith("events")) {
                const result = await DotNet.invokeMethodAsync('UniConnect', 'GetEventTypes');
                removeTypingIndicator();
                appendMessage("bot", result);
                return;
            }

            // Gemini fallback
            const res = await fetch(`https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=${API_KEY}`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    contents: [{ parts: [{ text: message }] }]
                })
            });

            const data = await res.json();
            removeTypingIndicator();
            let reply = data?.candidates?.[0]?.content?.parts?.[0]?.text?.trim() || "⚠️ No response.";

            const lowerMessage = message.toLowerCase();

            // Check if it's about lost/found
            if (lowerMessage.includes("lost") || lowerMessage.includes("found")) {
                try {
                    const lostFoundReply = await DotNet.invokeMethodAsync('UniConnect', 'SearchLostFoundItems', message);
                    reply += "<br><br>" + lostFoundReply;
                } catch (err) {
                    console.error(err);
                }
            }

            // Check if it's about events
            if (
                lowerMessage.includes("event") ||
                lowerMessage.includes("seminar") ||
                lowerMessage.includes("session") ||
                lowerMessage.includes("webinar") ||
                lowerMessage.includes("orientation") ||
                lowerMessage.includes("workshop")
            ) {
                try {
                    const eventReply = await DotNet.invokeMethodAsync('UniConnect', 'SearchEventInfo', message);
                    reply += "<br><br>" + eventReply;
                } catch (err) {
                    console.error(err);
                }
            }

            appendMessage("bot", reply);


        } catch (error) {
            removeTypingIndicator();
            appendMessage("bot", "❌ Error.");
            console.error(error);
        }
    }


    userInput?.addEventListener("keypress", function (e) {
        if (e.key === "Enter") sendMessage();
    });

    window.sendMessage = sendMessage; // expose to global so onclick works

    window.toggleChat = function () {
        const popup = document.getElementById("chatPopup");
        popup.style.display = popup.style.display === "block" ? "none" : "block";
    };

    window.hideChat = function () {
        document.getElementById("chatPopup").style.display = "none";
    };

    appendMessage("bot", "Hello! I am your AI assistant. Ask me anything.");
};
