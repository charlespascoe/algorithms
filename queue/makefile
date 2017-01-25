OUT=queue.exe
COMPILE=mcs -out:bin/$(OUT) -pkg:dotnet -recurse:'src/*.cs'

deps:
	cp ../linked-list/src/LinkedList.cs src/

all: deps
	mkdir -p bin/
	$(COMPILE)

debug: deps
	$(COMPILE) -debug
	mono --debug bin/$(OUT)

run: all
	mono bin/$(OUT)
