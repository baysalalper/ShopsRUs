FROM mongo
WORKDIR /

COPY ./ .
COPY ./import.sh .

RUN chmod +x import.sh

CMD ["sh", "-c", "/import.sh"]
