export interface ChatMessage {
    imageName: string;
    user: string;
    message: string;
}

export type ChatMessages = ChatMessage[];
