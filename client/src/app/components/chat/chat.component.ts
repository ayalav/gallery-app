import { Component } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { Picture } from 'src/app/interfaces/picture';
import { ChatMessages } from 'src/app/interfaces/chat';
import { PicturesService } from 'src/app/services/pictures.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnDestroy {

  myName: string = 'User' + Math.floor(Math.random() * 1000);
  newMessage: string = '';
  selectedPicture: Picture | null = null;
  chatMessages: ChatMessages = [];
  showHelpMessage: boolean = false;
  showHiMessage: boolean = false;
  socket: WebSocket | undefined;

  constructor(private picturesService: PicturesService) {
  }

  ngOnInit(): void {
    this.picturesService.selectedPicture$.subscribe(image => {
      if (image === null) return;
      this.selectedPicture = image;
      this.socket = new WebSocket('ws://localhost:5000/api/chat?user=' + this.myName + '&image=' + image.imageName);
      this.socket.addEventListener('message', (event) => {
        const receivedMessage = JSON.parse(event.data);
        console.log('receivedMessage: ', receivedMessage);
        this.chatMessages.push({
          imageName: receivedMessage.ImageName,
          user: receivedMessage.User,
          message: receivedMessage.Message
        });
      });
    });
  }

  ngOnDestroy(): void {
    this.socket?.close();
  }

  sendMessage(event: any) {
    this.newMessage = event.target.value.trim();
    if (this.newMessage !== '') {
      this.socket?.send(this.newMessage);
      this.chatMessages?.push({
        imageName: this.selectedPicture?.imageName!,
        user: this.myName,
        message: this.newMessage
      });
      this.newMessage = '';
    }
  }
}
